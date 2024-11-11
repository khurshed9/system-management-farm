using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;

namespace SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandHandler;

public class UpdateTransactionHandler(AppCommandDbContext context) : IRequestHandler<UpdateTransactionRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateTransactionRequest request, CancellationToken cancellationToken)
    {
        Transaction? existingTransaction = await context.Transactions
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingTransaction is null)
            return BaseResult.Failure(Error.NotFound());

        existingTransaction.ToUpdateTransaction(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}