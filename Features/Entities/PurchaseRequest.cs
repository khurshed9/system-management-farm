using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Domain.Entities;

public class PurchaseRequest : BaseEntity
{
    public int CropId { get; set; }
    public Crop Crop { get; set; }

    public int BusinessOwnerId { get; set; }
    public BusinessOwner BusinessOwner { get; set; }

    public decimal RequestedQuantity { get; set; }

    public DateTime RequestDate { get; set; }

    public PurchaseStatus Status { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = [];
}