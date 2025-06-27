using System.ComponentModel.DataAnnotations;
using Rent2Deliver.Domain;

namespace Rent2Deliver.API;

public class CreateRentalDto
{
    [Required]
    public Guid MotorcycleId { get; set; }
    [Required]
    public Guid DeliveryPersonId { get; set; }
    [Required]
    public RentalPlan Plan { get; set; }
}
