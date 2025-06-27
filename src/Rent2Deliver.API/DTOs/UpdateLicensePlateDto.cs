using System.ComponentModel.DataAnnotations;

namespace Rent2Deliver.API;

public class UpdateLicensePlateDto
{
    [Required]
    [MaxLength(10)]
    public string NewLicensePlate { get; set; }    
}
