﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaOne.Data.Models;

public partial class Driver
{
    [Key]
    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Column("birth_date")]
    public DateOnly BirthDate { get; set; }

    [Column("nationality")]
    [StringLength(100)]
    public string Nationality { get; set; } = null!;

    [Column("team_id")]
    public int? TeamId { get; set; }

    [InverseProperty("Driver")]
    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    [ForeignKey("TeamId")]
    [InverseProperty("Drivers")]
    public virtual Team? Team { get; set; }
}
