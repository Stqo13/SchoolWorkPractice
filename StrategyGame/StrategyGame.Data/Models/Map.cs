using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public string? Description { get; set; }
    }
}
