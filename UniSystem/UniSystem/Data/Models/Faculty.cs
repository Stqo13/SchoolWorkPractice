using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniSystem.Data.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public int UniversityId { get; set; }

        [ForeignKey(nameof(UniversityId))]
        public virtual University University { get; set; } = null!;

        public virtual ICollection<Major> Majors { get; set; } = new List<Major>(); 
    }
}
