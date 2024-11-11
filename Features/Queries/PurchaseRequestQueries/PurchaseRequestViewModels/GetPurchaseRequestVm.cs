using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;
using SystemManagementFactory.Features.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;

public readonly record struct GetPurchaseRequestVm(
    int Id,
    PurchaseRequestBaseInfo PurchaseRequestBaseInfo);
    
    
public record GetPurchaseRequestVmRequest(PurchaseRequestFilter Filter) : IRequest<Result<PaginationResponse<IEnumerable<GetPurchaseRequestVm>>>>;