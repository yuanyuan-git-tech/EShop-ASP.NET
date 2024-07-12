namespace ApplicationCore.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set;}
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeafultAddress { get; set; }
        
        // Navigation property
        public Customer Customer { get; set; }
    }
}
