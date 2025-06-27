using System.ComponentModel.DataAnnotations;

namespace Rent2Deliver.API;

public class UploadLicenseImageDto
{
    [Required]
    public IFormFile File { get; set; }
}
