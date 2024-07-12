namespace ApplicationCore.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid CustomerId { get; set; }
    // public string CustomerName { get; set; }
    public int PaymentMethod { get;set; }
    // public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public int ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    public int OrderStatusId { get; set; }
    
    // Navigation property
    public OrderStatus OrderStatus { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
}