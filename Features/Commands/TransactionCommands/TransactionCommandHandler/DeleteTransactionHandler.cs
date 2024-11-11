using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandHandler;

public class DeleteTransactionHandler(IUnitOfWork<Transaction> unitOfWork) : IRequestHandler<DeleteTransactionRequest, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteTransactionRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Transaction> repository = unitOfWork.TransactionDeleteRepository;
        IGenericFindRepository<Transaction> findRepository = unitOfWork.TransactionFindRepository;

        Transaction? transaction = await findRepository.GetByIdAsync(request.Id);
        if(transaction is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(transaction);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}