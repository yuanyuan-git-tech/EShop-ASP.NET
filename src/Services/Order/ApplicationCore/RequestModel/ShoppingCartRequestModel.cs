namespace ApplicationCore.RequestModel;

public class ShoppingCartRequestModel
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItemRequestModel> ShoppingItems { get; set; }
}