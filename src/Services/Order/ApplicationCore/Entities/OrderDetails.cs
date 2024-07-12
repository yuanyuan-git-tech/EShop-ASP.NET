namespace ApplicationCore.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; } 
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    
    // Navigation property
    public Order Order { get; set; }
}