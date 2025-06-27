using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public interface IRentalRepository
{
    Task AddAsync(Rental rental);
    Task<Rental?> GetByIdAsync(Guid id);
    Task<IEnumerable<Rental>> GetByDeliveryPersonIdAsync(Guid deliveryPersonId);
    Task<IEnumerable<Rental>> GetByMotorcycleIdAsync(Guid motorcycleId);
    Task UpdateReturnDateAsync(Guid id, DateTime actualReturnDate);
}
