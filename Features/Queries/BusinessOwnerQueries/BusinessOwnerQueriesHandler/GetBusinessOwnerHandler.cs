using System.Linq.Expressions;
using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.Responses;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerQueriesHandler;

public class GetBusinessOwnerHandler(IUnitOfWork<BusinessOwner> unitOfWork) : IRequestHandler<GetBusinessOwnerVmRequest, Result<PaginationResponse<IEnumerable<GetBusinessOwnerVm>>>>
{
    public async Task<Result<PaginationResponse<IEnumerable<GetBusinessOwnerVm>>>> Handle(GetBusinessOwnerVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<BusinessOwner> repository = unitOfWork.BusinessOwnerFindRepository;
        
        Expression<Func<BusinessOwner, bool>> filterExpression = businessOwner =>
            (request.Filter.CompanyName == null || businessOwner.CompanyName == request.Filter.CompanyName);

        IEnumerable<BusinessOwner> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();
        
        IEnumerable<GetBusinessOwnerVm> businessOwners = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();
        
        PaginationResponse<IEnumerable<GetBusinessOwnerVm>> response = PaginationResponse<IEnumerable<GetBusinessOwnerVm>>.Create(request.Filter.PageNumber, request.Filter.PageSize,
            totalRecords, businessOwners);
        
        return Result<PaginationResponse<IEnumerable<GetBusinessOwnerVm>>>.Success(response);
    }
}