namespace ApplicationCore.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        
        public ICollection<ShoppingCartItem> ShoppingItems { get; set; }
    }
}
