using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;

public readonly record struct CreatePurchaseRequestRequest(
    PurchaseRequestBaseInfo PurchaseRequestBaseInfo) : IRequest<BaseResult>;