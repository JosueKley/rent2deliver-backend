using Microsoft.EntityFrameworkCore;
using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public class DeliveryPersonRepository : IDeliveryPersonRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public DeliveryPersonRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task AddAsync(DeliveryPerson deliveryPerson)
    {
        _dbContext.DeliveryPersons.Add(deliveryPerson);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<DeliveryPerson?> GetByIdAsync(Guid id)
    {
        return await _dbContext.DeliveryPersons.FindAsync(id);
    }
    
    public async Task<DeliveryPerson?> GetByCnpjAsync(string cnpj)
    {
        return await _dbContext.DeliveryPersons.FirstOrDefaultAsync(e => e.Cnpj == cnpj);
    }
    
    public async Task<DeliveryPerson?> GetByLicenseNumberAsync(string licenseNumber)
    {
        return await _dbContext.DeliveryPersons.FirstOrDefaultAsync(e => e.LicenseNumber == licenseNumber);
    }
    
    public async Task UpdateLicenseImageUrlAsync(Guid id, string imageUrl)
    {
        var entregador = await _dbContext.DeliveryPersons.FindAsync(id);
        if (entregador != null)
        {
            entregador.LicenseImageUrl = imageUrl;
            await _dbContext.SaveChangesAsync();
        }
    } 
}