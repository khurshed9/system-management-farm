using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Features.Queries.TransactionQueries.TransactionViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.TransactionQueries.TransactionQueryHandler;

public class GetTransactionByIdHandler(IUnitOfWork<Transaction> unitOfWork) : IRequestHandler<GetTransactionByIdVmRequest, Result<GetTransactionByIdVm>>
{
    public async Task<Result<GetTransactionByIdVm>> Handle(GetTransactionByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Transaction> repository = unitOfWork.TransactionFindRepository;
        Transaction? transaction = await repository.GetByIdAsync(request.Id);
        GetTransactionByIdVm viewModel = transaction.ToReadByIdInfo();

        return Result<GetTransactionByIdVm>.Success(viewModel);
    }
}