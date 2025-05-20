using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Models
{

    [PrimaryKey(nameof(PlayerId), nameof(UnitId))]
    public class PlayerUnit
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;
        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
