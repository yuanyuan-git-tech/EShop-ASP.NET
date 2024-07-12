using ApplicationCore.Entities;

namespace ApplicationCore.RequestModel;

public class OrderViewModel
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int PaymentMethod { get;set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public int ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    public int OrderStatusId { get; set; }
    
    public string OrderStatus { get; set; }
    public List<OrderDetailViewModel> OrderDetails { get; set; }
}