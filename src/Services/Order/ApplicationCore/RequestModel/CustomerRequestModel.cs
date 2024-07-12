using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.RequestModel;

public class CustomerRequestModel
{
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Phone { get; set; }
    public string ProfilePic { get; set; }
    public Guid UserId { get; set; }
    // public List<AddressRequestModel> Address { get; set; }
}