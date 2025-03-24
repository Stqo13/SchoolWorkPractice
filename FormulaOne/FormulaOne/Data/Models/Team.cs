using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaOne.Data.Models;

public partial class Team
{
    [Key]
    [Column("team_id")]
    public int TeamId { get; set; }

    [Column("team_name")]
    [StringLength(100)]
    public string TeamName { get; set; } = null!;

    [Column("country")]
    [StringLength(100)]
    public string Country { get; set; } = null!;

    [Column("foundation_year")]
    public int FoundationYear { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
