using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Features.Queries.TransactionQueries.TransactionViewModels;

namespace SystemManagementFactory.Extensions.Mapper;

public static class TransactionMappingExtensions
{
    public static GetTransactionVm ToReadInfo(this Transaction transaction)
    {
        return new()
        {
            Id = transaction.Id,
            TransactionBaseInfo = new()
            {
                PurchaseRequestId = transaction.PurchaseRequestId,
                TransactionDate = transaction.TransactionDate,
                TotalAmount = transaction.TotalAmount
            }
        };
    }
    
    public static GetTransactionByIdVm ToReadByIdInfo(this Transaction transaction)
    {
        return new()
        {
            Id = transaction.Id,
            TransactionBaseInfo = new()
            {
                PurchaseRequestId = transaction.PurchaseRequestId,
                TransactionDate = transaction.TransactionDate,
                TotalAmount = transaction.TotalAmount
            }
        };
    }

    public static Transaction ToTransaction(this CreateTransactionRequest createInfo)
    {
        return new()
        {
            PurchaseRequestId = createInfo.TransactionBaseInfo.PurchaseRequestId,
            TransactionDate = createInfo.TransactionBaseInfo.TransactionDate,
            TotalAmount = createInfo.TransactionBaseInfo.TotalAmount
        };
    }

    public static Transaction ToUpdateTransaction(this Transaction transaction ,UpdateTransactionRequest updateInfo)
    {
        transaction.PurchaseRequestId = updateInfo.TransactionBaseInfo.PurchaseRequestId;
        transaction.TransactionDate = updateInfo.TransactionBaseInfo.TransactionDate;
        transaction.TotalAmount = updateInfo.TransactionBaseInfo.TotalAmount;
        transaction.Version++;
        transaction.UpdatedAt = DateTime.UtcNow;
        return transaction;
    }

    public static Transaction ToDeletedTransaction(this Transaction transaction, UpdateTransactionRequest request)
    {
        transaction.IsDeleted = true;
        transaction.DeletedAt = DateTime.UtcNow;
        transaction.UpdatedAt = DateTime.UtcNow;
        transaction.Version++;
        return transaction;
    }
}