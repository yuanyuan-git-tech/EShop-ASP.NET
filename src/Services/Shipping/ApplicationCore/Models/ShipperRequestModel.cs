
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class ShipperRequestModel
{
    [Required(ErrorMessage = "Please enter the name of the shipper")]
    [StringLength(255, MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please enter the email address of the shipper")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(255)]
    public string Email { get; set; }
    
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a 10-digit U.S. phone number.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Please enter name of the contact person")]
    [StringLength(255, MinimumLength = 2)]
    public string ContactPerson { get; set; }
}