using Microsoft.EntityFrameworkCore;
using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public class RentalRepository : IRentalRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RentalRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddAsync(Rental rental)
    {
        _dbContext.Rentals.Add(rental);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rental>> GetByDeliveryPersonIdAsync(Guid deliveryPersonId)
    {
        return await _dbContext.Rentals
            .Where(r => r.DeliveryPersonId == deliveryPersonId)
            .ToListAsync();
    }

    public async Task<Rental?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Rentals.FindAsync(id);
    }

    public async Task<IEnumerable<Rental>> GetByMotorcycleIdAsync(Guid motorcycleId)
    {
        return await _dbContext.Rentals
            .Where(r => r.MotorcycleId == motorcycleId)
            .ToListAsync();
    }

    public async Task UpdateReturnDateAsync(Guid id, DateTime actualReturnDate)
    {
        var rental = await _dbContext.Rentals.FindAsync(id);
        if (rental != null)
        {
            rental.ActualReturnDate = actualReturnDate;
            await _dbContext.SaveChangesAsync();
        }
    }
}
