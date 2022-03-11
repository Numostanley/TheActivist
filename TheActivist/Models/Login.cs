using System.ComponentModel.DataAnnotations;

// The codes for this Model was aided through the youtube resource : https://www.youtube.com/watch?v=B0_gM-wBlmE

namespace TheActivist.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
