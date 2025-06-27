using System.ComponentModel.DataAnnotations;

namespace Rent2Deliver.API;

public class CalculateReturnDto
{
    [Required]
    public DateTime ActualReturnDate { get; set; }
}
