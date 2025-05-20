using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Models
{
    [PrimaryKey(nameof(PlayerId), nameof(ResourceId))]
    public class PlayerResource
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        public int ResourceId { get; set; }

        [ForeignKey(nameof(ResourceId))]
        public virtual Resource Resource { get; set; } = null!;

        public int Amount { get; set; }

    }
}
