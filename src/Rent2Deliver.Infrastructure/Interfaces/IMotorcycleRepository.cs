using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public interface IMotorcycleRepository
{
    Task AddAsync(Motorcycle motorcycle);
    Task<Motorcycle?> GetByIdAsync(Guid id);
    Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate);
    Task<IEnumerable<Motorcycle>> GetAllAsync(string? licensePlateFilter = null);
    Task UpdateLicensePlateAsync(Guid id, string newLicensePlate);
    Task DeleteAsync(Guid id);
    Task<bool> HasRentalAsync(Guid motorcycleId);
}
