namespace SystemManagementFactory.Features.BaceInfos;

public readonly record struct TransactionBaseInfo(
    int PurchaseRequestId, 
    DateTime TransactionDate,
    decimal TotalAmount);