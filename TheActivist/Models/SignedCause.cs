using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TheActivist.Models
{
    public class SignedCause
    {
        [Key]
        public int Id { get; set; }

        public string? CauseName { get; set; }

        public string? UserName { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
