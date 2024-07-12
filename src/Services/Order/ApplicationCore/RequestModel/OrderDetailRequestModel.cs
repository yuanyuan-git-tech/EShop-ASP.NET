namespace ApplicationCore.RequestModel;

public class OrderDetailRequestModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}