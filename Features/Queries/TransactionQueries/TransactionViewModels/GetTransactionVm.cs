using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Features.Queries.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.Features.Queries.TransactionQueries.TransactionViewModels;

public readonly record struct GetTransactionVm(
    int Id,
    TransactionBaseInfo TransactionBaseInfo);
    
    
public record GetTransactionVmRequest(TransactionFilter Filter) : IRequest<Result<PaginationResponse<IEnumerable<GetTransactionVm>>>>;