using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Queries.PurchaseRequestQueries.PurchaseRequestViewModels;

public readonly record struct GetPurchaseRequestByIdVm(
    int Id,
    PurchaseRequestBaseInfo PurchaseRequestBaseInfo);
    
    
public record GetPurchaseRequestByIdVmRequest(int Id) :   IRequest<Result<GetPurchaseRequestByIdVm>>;