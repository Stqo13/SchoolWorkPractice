using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int ResearchTime { get; set; }
    }
}
