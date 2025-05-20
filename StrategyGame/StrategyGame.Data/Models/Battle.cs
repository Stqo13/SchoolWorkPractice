using StrategyGame.Data.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Battle
    {
        [Key]
        public int Id { get; set; }

        public int AttackerId { get; set; }

        [ForeignKey(nameof(AttackerId))]
        public Player Attacker { get; set; } = null!;

        public int DefenderId { get; set; }

        [ForeignKey(nameof(DefenderId))]
        public virtual Player Defender { get; set; } = null!;

        public DateTime StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        public BattleResult Result { get; set; }


        public virtual ICollection<BattleUnit> BattleUnits { get; set; } = new List<BattleUnit>();
    }
}
