using System.ComponentModel.DataAnnotations;

namespace DriversAPI.Models.DTOs
{
    public class DriverDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
