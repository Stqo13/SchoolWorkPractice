using System.ComponentModel.DataAnnotations;

namespace UniSystem.Data.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}
