using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int AttackPower { get; set; }

        public int DefensePower { get; set; }

        public int TrainingTime { get; set; }

        public int FactionId { get; set; }

        [ForeignKey(nameof(FactionId))]
        public virtual Faction Faction { get; set; } = null!;
    }
}
