using System.Linq.Expressions;
using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Features.Queries.TransactionQueries.TransactionViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.Responses;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.TransactionQueries.TransactionQueryHandler;

public sealed class GetTransactionsHandler(IUnitOfWork<Transaction> unitOfWork) : IRequestHandler<GetTransactionVmRequest,Result<PaginationResponse<IEnumerable<GetTransactionVm>>>>
{
    public async Task<Result<PaginationResponse<IEnumerable<GetTransactionVm>>>> Handle(GetTransactionVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Transaction> repository = unitOfWork.TransactionFindRepository;
        
        Expression<Func<Transaction, bool>> filterExpression = transaction =>
            (request.Filter.TotalAmount == null || transaction.TotalAmount >= request.Filter.TotalAmount);

        IEnumerable<Transaction> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();

        IEnumerable<GetTransactionVm> transactions = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();

        PaginationResponse<IEnumerable<GetTransactionVm>> response = PaginationResponse<IEnumerable<GetTransactionVm>>.Create(request.Filter.PageNumber, request.Filter.PageSize,
            totalRecords, transactions);
        
        return Result<PaginationResponse<IEnumerable<GetTransactionVm>>>.Success(response);
    }
}