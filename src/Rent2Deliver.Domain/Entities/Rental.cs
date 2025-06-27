namespace Rent2Deliver.Domain;

public class Rental
{
    public Guid Id { get; set; }
    public Guid MotorcycleId { get; set; }
    public Guid DeliveryPersonId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ExpectedEndDate { get; set; }
    public int PlanDays { get; set; }
    public decimal DailyRate { get; set; }
}
