using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Models
{
    [PrimaryKey(nameof(PlayerId), nameof(FactionId))]
    public class PlayerFaction
    {

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        public int FactionId { get; set; }

        [ForeignKey(nameof(FactionId))]
        public virtual Faction Faction { get; set; } = null!;

        public DateTime StartDate { get; set; }
    }
}
