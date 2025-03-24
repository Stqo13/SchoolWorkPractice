using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Data.Models;

public partial class Race
{
    [Key]
    [Column("race_id")]
    public int RaceId { get; set; }

    [Column("race_name")]
    [StringLength(255)]
    public string RaceName { get; set; } = null!;

    [Column("location")]
    [StringLength(255)]
    public string Location { get; set; } = null!;

    [Column("race_date")]
    public DateOnly RaceDate { get; set; }

    [Column("season_year")]
    public int SeasonYear { get; set; }

    [InverseProperty("Race")]
    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
}
