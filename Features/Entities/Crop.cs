namespace SystemManagementFactory.Domain.Entities;

public class Crop : BaseEntity
{
    public string Name { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal PricePerUnit { get; set; }

    public int FarmerGardenId { get; set; }
    public FarmerGarden FarmerGarden { get; set; }
}