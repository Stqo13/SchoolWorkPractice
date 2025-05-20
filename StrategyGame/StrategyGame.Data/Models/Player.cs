using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<PlayerFaction> PlayerFactions { get; set; } = new List<PlayerFaction>();
        public virtual ICollection<PlayerBuilding> PlayerBuildings { get; set; } = new List<PlayerBuilding>();
        public virtual ICollection<PlayerUnit> PlayerUnits { get; set; } = new List<PlayerUnit>();
        public virtual ICollection<PlayerResource> PlayerResources { get; set; } = new List<PlayerResource>();
        public virtual ICollection<PlayerTechnology> PlayerTechnologies { get; set; } = new List<PlayerTechnology>();
        public virtual ICollection<PlayerLocation> PlayerLocations { get; set; } = new List<PlayerLocation>();
    }
}
