using Rent2Deliver.Domain;

namespace Rent2Deliver.API;

public class DeliveryPersonDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public DateTime BirthDate { get; set; }
    public string LicenseNumber { get; set; }
    public LicenseType LicenseType { get; set; }
    public string LicenseImageUrl { get; set; }
}
