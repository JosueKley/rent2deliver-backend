using Microsoft.EntityFrameworkCore;
using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public class MotorcycleRepository : IMotorcycleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MotorcycleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Motorcycle motorcycle)
    {
        _dbContext.Motorcycles.Add(motorcycle);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Motorcycle?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Motorcycles.FindAsync(id);
    }

    public async Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate)
    {
        return await _dbContext.Motorcycles.FirstOrDefaultAsync(m => m.LicensePlate == licensePlate);
    }

    public async Task<IEnumerable<Motorcycle>> GetAllAsync(string? licensePlateFilter = null)
    {
        var query = _dbContext.Motorcycles.AsQueryable();
        if (!string.IsNullOrEmpty(licensePlateFilter))
            query = query.Where(m => m.LicensePlate.Contains(licensePlateFilter));
        return await query.ToListAsync();
    }

    public async Task UpdateLicensePlateAsync(Guid id, string newLicensePlate)
    {
        var moto = await _dbContext.Motorcycles.FindAsync(id);
        if (moto != null)
        {
            moto.LicensePlate = newLicensePlate;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var moto = await _dbContext.Motorcycles.FindAsync(id);
        if (moto != null)
        {
            _dbContext.Motorcycles.Remove(moto);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> HasRentalAsync(Guid motorcycleId)
    {
        return await _dbContext.Rentals.AnyAsync(r => r.MotorcycleId == motorcycleId);
    }
}