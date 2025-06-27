using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public interface IDeliveryPersonRepository
{
    Task AddAsync(DeliveryPerson deliveryPerson);
    Task<DeliveryPerson?> GetByIdAsync(Guid id);
    Task<DeliveryPerson?> GetByCnpjAsync(string cnpj);
    Task<DeliveryPerson?> GetByLicenseNumberAsync(string licenseNumber);
    Task UpdateLicenseImageUrlAsync(Guid id, string imageUrl);
}
