using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TheActivist.Models
{
    [Index(nameof(CausesName), IsUnique = true)]
    public class CauseClass
    {
        [Key]
        public int CausesId { get; set; }

        [Required]
        public string? CausesName { get; set; }

        [Required]
        public string? CausesDescription { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
