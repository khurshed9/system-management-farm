using System.Linq.Expressions;
using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.Responses;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.PurchaseRequestQueries.PurchaseRequestQueriesHandler;

public class GetPurchaseRequestHandler(IUnitOfWork<PurchaseRequest> unitOfWork) : IRequestHandler<GetPurchaseRequestVmRequest, Result<PaginationResponse<IEnumerable<GetPurchaseRequestVm>>>>
{
    public async Task<Result<PaginationResponse<IEnumerable<GetPurchaseRequestVm>>>> Handle(GetPurchaseRequestVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<PurchaseRequest> repository = unitOfWork.PurchaseRequestFindRepository;
        
        Expression<Func<PurchaseRequest, bool>> filterExpression = purchaseRequest =>
            (request.Filter.Status == null || purchaseRequest.Status == request.Filter.Status);

        IEnumerable<PurchaseRequest> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();
        
        IEnumerable<GetPurchaseRequestVm> purchaseRequest = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();
        
        PaginationResponse<IEnumerable<GetPurchaseRequestVm>> response = PaginationResponse<IEnumerable<GetPurchaseRequestVm>>.Create(request.Filter.PageNumber, request.Filter.PageSize,
            totalRecords, purchaseRequest);
        
        return Result<PaginationResponse<IEnumerable<GetPurchaseRequestVm>>>.Success(response);
    }
}