using System.Linq.Expressions;
using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.Responses;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerQueriesHandler;

public class GetCropHandler(IUnitOfWork<Crop> unitOfWork) : IRequestHandler<GetCropVmRequest, Result<PaginationResponse<IEnumerable<GetCropVm>>>>
{
    public async Task<Result<PaginationResponse<IEnumerable<GetCropVm>>>> Handle(GetCropVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Crop> repository = unitOfWork.CropFindRepository;
        
        Expression<Func<Crop, bool>> filterExpression = crop =>
            (request.Filter.Name == null || crop.Name == request.Filter.Name);

        IEnumerable<Crop> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();
        
        IEnumerable<GetCropVm> crops = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();
        
        PaginationResponse<IEnumerable<GetCropVm>> response = PaginationResponse<IEnumerable<GetCropVm>>.Create(request.Filter.PageNumber, request.Filter.PageSize,
            totalRecords, crops);
        
        return Result<PaginationResponse<IEnumerable<GetCropVm>>>.Success(response);
    }
}