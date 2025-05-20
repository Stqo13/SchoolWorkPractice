using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Models
{
    [PrimaryKey(nameof(PlayerId), nameof(TechnologyId))]
    public class PlayerTechnology
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        public int TechnologyId { get; set; }

        [ForeignKey(nameof(TechnologyId))]
        public virtual Technology Technology { get; set; } = null!;

        public bool IsResearched { get; set; }

        public DateTime? ResearchedAt { get; set; }

    }
}
