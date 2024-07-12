using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.RequestModel;

public class AddressRequestModel
{
    public int Id { get; set; }
    [Required]
    public string Street1 { get; set; }
    public string Street2 { get; set;}
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Country { get; set; }
    public int CustomerId { get; set; }
    public bool IsDeafultAddress { get; set; }
}