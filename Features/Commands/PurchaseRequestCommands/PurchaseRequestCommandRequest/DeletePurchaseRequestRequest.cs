using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;

public readonly record struct DeletePurchaseRequestRequest(int Id) : IRequest<BaseResult>;