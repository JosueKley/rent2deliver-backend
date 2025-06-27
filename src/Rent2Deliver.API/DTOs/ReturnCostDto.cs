namespace Rent2Deliver.API;

public class ReturnCostDto
{
    public decimal TotalDailyCost { get; set; }
    public decimal PenaltyOrExtra { get; set; }
    public decimal GrandTotal { get; set; }
}
