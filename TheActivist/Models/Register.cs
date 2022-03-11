using System.ComponentModel.DataAnnotations;


// The codes for this Model was aided through the youtube resource : https://www.youtube.com/watch?v=B0_gM-wBlmE

namespace TheActivist.Models
{
    public class Register
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Password and Confirm Password did not match")]
        public string? confirmPassword { get; set; }
    }
}
