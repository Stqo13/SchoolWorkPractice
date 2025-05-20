using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace StrategyGame.Data.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int BuildTime { get; set; }

        public int FactionId { get; set; }

        [ForeignKey(nameof(FactionId))]
        public virtual Faction Faction { get; set; } = null!;
    }
}
