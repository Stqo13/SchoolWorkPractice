using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Models
{

    [PrimaryKey(nameof(PlayerId), nameof(MapId))]
    public class PlayerLocation
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        public int MapId { get; set; }

        [ForeignKey(nameof(MapId))]
        public virtual Map Map { get; set; } = null!;

        public int X { get; set; }
        public int Y { get; set; }

    }
}
