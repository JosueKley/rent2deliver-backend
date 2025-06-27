namespace Rent2Deliver.Domain;

public class MotorcycleRegisteredEvent
{
    public Guid Id { get; set; }
    public Guid MotorcycleId { get; set; }
    public DateTime Timestamp { get; set; }
    public int Year { get; set; }
}
