using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormHandling.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name cannot be empty")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Invalid date format")]
        public DateTime DateOfBirth { get; set; } = new DateTime(2000, 01, 01);
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Select a state")]
        public string State { get; set; } = string.Empty;
        [Required]
        public string ZipCode { get; set; } = string.Empty;
    }
}
