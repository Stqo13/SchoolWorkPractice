using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Models
{
    [PrimaryKey(nameof(PlayerId), nameof(BuildingId))]
    public class PlayerBuilding
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        public int BuildingId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        public virtual Building Building { get; set; } = null!;

        public int Level { get; set; }

        public DateTime BuiltAt { get; set; }
    }
}
