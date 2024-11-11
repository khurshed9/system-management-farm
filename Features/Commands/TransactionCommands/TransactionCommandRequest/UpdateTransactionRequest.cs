using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;

public readonly record struct UpdateTransactionRequest(
    int Id,
    TransactionBaseInfo TransactionBaseInfo) : IRequest<BaseResult>;
