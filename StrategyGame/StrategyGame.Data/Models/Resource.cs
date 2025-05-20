using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
