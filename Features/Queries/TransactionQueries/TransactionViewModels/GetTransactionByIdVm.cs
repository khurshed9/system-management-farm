using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Queries.TransactionQueries.TransactionViewModels;

public readonly record struct GetTransactionByIdVm(
    int Id,
    TransactionBaseInfo TransactionBaseInfo);
    
    
public record GetTransactionByIdVmRequest(int Id) :   IRequest<Result<GetTransactionByIdVm>>;