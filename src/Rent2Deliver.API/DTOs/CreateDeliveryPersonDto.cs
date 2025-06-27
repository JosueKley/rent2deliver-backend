using System.ComponentModel.DataAnnotations;
using Rent2Deliver.Domain;

namespace Rent2Deliver.API;

public class CreateDeliveryPersonDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [RegularExpression(@"\d{14}")]
    public string Cnpj { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    [MaxLength(20)]
    public string LicenseNumber { get; set; }
    [Required]
    public LicenseType LicenseType { get; set; }
}
