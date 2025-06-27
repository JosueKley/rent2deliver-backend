namespace Rent2Deliver.API;

public class RentalDto
{
    public Guid Id { get; set; }
    public Guid MotorcycleId { get; set; }
    public Guid DeliveryPersonId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpectedEndDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PlanDays { get; set; }
    public decimal DailyRate { get; set; }
}
