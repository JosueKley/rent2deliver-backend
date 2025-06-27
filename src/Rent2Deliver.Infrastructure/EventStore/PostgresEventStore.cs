using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public class PostgresEventStore
{
    private readonly ApplicationDbContext _context;

    public PostgresEventStore(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveMotorcycleRegisteredEventAsync(MotorcycleRegisteredEvent motorcycleRegisteredEvent)
    {
        var @event = new MotorcycleRegisteredEvent
        {
            Id = Guid.NewGuid(),
            MotorcycleId = motorcycleRegisteredEvent.MotorcycleId,
            Timestamp = DateTime.UtcNow,
            Year = motorcycleRegisteredEvent.Year
        };

        _context.Set<MotorcycleRegisteredEvent>().Add(@event);
        await _context.SaveChangesAsync();
    }
}