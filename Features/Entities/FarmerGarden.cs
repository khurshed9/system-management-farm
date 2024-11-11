using System.ComponentModel.DataAnnotations;
using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Domain.Entities;

public class FarmerGarden : BaseEntity
{
    [Required(ErrorMessage = "Name shouldn't be null")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Description shouldn't be null")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "LandSize shouldn't be null")]
    public decimal LandSize { get; set; }

    [Required(ErrorMessage = "Status shouldn't be null")]
    public GardenStatus Status { get; set; }

    [Required(ErrorMessage = "FarmerId shouldn't be null")]
    public int FarmerId { get; set; }
    public Farmer Farmer { get; set; }

    public ICollection<Crop> Crops { get; set; }
}