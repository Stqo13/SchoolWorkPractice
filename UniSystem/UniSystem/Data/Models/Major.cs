using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniSystem.Data.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public int FacultyId { get; set; }

        [ForeignKey(nameof(FacultyId))]
        public virtual Faculty Faculty { get; set; } = null!;
    }
}
