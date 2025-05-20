using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Faction
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        public string? Description { get; set; }

        public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();
        public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
    }
}
