namespace SystemManagementFactory.Domain.Entities;

public class Transaction : BaseEntity
{
    public int PurchaseRequestId { get; set; }
    public PurchaseRequest PurchaseRequest { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal TotalAmount { get; set; }
}