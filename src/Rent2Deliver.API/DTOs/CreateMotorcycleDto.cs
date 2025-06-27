using System.ComponentModel.DataAnnotations;

namespace Rent2Deliver.API;

public class CreateMotorcycleDto
{
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string LicensePlate { get; set; }
}
