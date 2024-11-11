using System.Collections;
using System.Linq.Expressions;
using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.Responses;
using SystemManagementFactory.UOW;
using GetFarmerVmRequest = SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels.GetFarmerGardenVmRequest;

namespace SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenQueryHandler;

public class GetFarmerGardensHandler(IUnitOfWork<FarmerGarden> _unitOfWork) : IRequestHandler<GetFarmerGardenVmRequest,Result<PaginationResponse<IEnumerable<GetFarmerGardenVm>>>>
{
    public async Task<Result<PaginationResponse<IEnumerable<GetFarmerGardenVm>>>> Handle(GetFarmerGardenVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<FarmerGarden> repository = _unitOfWork.FarmerGardenFindRepository;
        
        Expression<Func<FarmerGarden, bool>> filterExpression = farmerGarden =>
            (request.Filter.LandSize == null || farmerGarden.LandSize >= request.Filter.LandSize);

        IEnumerable<FarmerGarden> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();

        IEnumerable<GetFarmerGardenVm> farmerGardens = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();

        PaginationResponse<IEnumerable<GetFarmerGardenVm>> response = PaginationResponse<IEnumerable<GetFarmerGardenVm>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, totalRecords, farmerGardens);
        
        return Result<PaginationResponse<IEnumerable<GetFarmerGardenVm>>>.Success(response);
    }
}