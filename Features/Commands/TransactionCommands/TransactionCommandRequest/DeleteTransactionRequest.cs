using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;

public readonly record struct DeleteTransactionRequest(
    int Id) : IRequest<BaseResult>;
