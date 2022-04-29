namespace EFCorePerformanceExample.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
}
