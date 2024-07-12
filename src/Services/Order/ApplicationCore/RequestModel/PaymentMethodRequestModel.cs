namespace ApplicationCore.RequestModel;

public class PaymentMethodRequestModel
{
    public int Id { set; get; }
    public string Provider { set; get; }
    public string AccountNumber { get; set; }
    public DateTime Expiry { get; set; }
    public bool IsDefault { get; set; }
    public int PaymentTypeId { get; set; }
    public Guid CustomerId { get; set; }
    public string PaymentTypeName { get; set; }
}