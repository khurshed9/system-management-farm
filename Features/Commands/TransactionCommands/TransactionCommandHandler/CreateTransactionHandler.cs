using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandHandler;

public class CreateTransactionHandler(IUnitOfWork<Transaction> unitOfWork) : IRequestHandler<CreateTransactionRequest, BaseResult>
{
    public async Task<BaseResult> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Transaction> repository = unitOfWork.TransactionAddRepository;

        if (request.TransactionBaseInfo.TotalAmount <= 0)
            return BaseResult.Failure(Error.BadRequest("Amount must be greater than zero."));

        await repository.AddAsync(request.ToTransaction());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data not saved!!!"));
    }
}