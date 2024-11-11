using System.ComponentModel.DataAnnotations;

namespace SystemManagementFactory.Domain.Entities;

public class BusinessOwner : BaseEntity
{
    [Required(ErrorMessage = "FullName shouldn't be null")]
    [MaxLength(30)]
    public string FullName { get; set; } = null!;
    
    [Required(ErrorMessage = "CompanyName shouldn't be null")]
    [MaxLength(50)]
    public string CompanyName { get; set; } = null!;

    [Required(ErrorMessage = "PhoneNumber shouldn't be null")]
    [Phone]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Address shouldn't be null")]
    [EmailAddress]
    public string Address { get; set; } = null!;

    public ICollection<PurchaseRequest> PurchaseRequests { get; set; } = [];
}