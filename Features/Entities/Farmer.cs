using System.ComponentModel.DataAnnotations;
using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Domain.Entities;

public class Farmer : BaseEntity
{
    [Required(ErrorMessage = "FullName shouldn't be null")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Address shouldn't be null")]
    [EmailAddress]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "PhoneNumber shouldn't be null")]
    [Phone]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Gender shouldn't be null")]
    [MaxLength(6),MinLength(4)]
    public FarmerGender Gender { get; set; }

    
    public int Experience { get; set; }

    public ICollection<FarmerGarden> FarmerGardens { get; set; } = [];
}