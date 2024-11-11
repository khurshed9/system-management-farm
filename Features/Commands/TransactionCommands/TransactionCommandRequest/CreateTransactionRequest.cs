using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;

public readonly record struct CreateTransactionRequest(
    TransactionBaseInfo TransactionBaseInfo) : IRequest<BaseResult>;
