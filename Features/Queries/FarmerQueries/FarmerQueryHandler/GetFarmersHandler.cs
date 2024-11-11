using System.Collections;
using System.Linq.Expressions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.Responses;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.FarmerQueryHandler;

public sealed class GetFarmersHandler(IUnitOfWork<Farmer> _unitOfWork) : IRequestHandler<GetFarmerVmRequest, Result<PaginationResponse<IEnumerable<GetFarmerVm>>>>
{

    public async Task<Result<PaginationResponse<IEnumerable<GetFarmerVm>>>> Handle(GetFarmerVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Farmer> repository = _unitOfWork.FarmerFindRepository;
        
        Expression<Func<Farmer, bool>> filterExpression = farmer =>
            (request.Filter.Experience == null || farmer.Experience >= request.Filter.Experience);

        IEnumerable<Farmer> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();

        IEnumerable<GetFarmerVm> farmers = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();

        PaginationResponse<IEnumerable<GetFarmerVm>> response = PaginationResponse<IEnumerable<GetFarmerVm>>.Create(request.Filter.PageNumber, request.Filter.PageSize,
            totalRecords, farmers);
        
        return Result<PaginationResponse<IEnumerable<GetFarmerVm>>>.Success(response);
        
    }
}
