using FormulaOne.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Data;

public partial class FormulaOneDbContext : DbContext
{
    public FormulaOneDbContext()
    {
    }

    public FormulaOneDbContext(DbContextOptions<FormulaOneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=STUDENT24;Database=FormulaOneDb;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Drivers__A411C5BD77A9EDB4");

            entity.HasOne(d => d.Team).WithMany(p => p.Drivers).HasConstraintName("FK__Drivers__team_id__398D8EEE");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("PK__Races__1C8FE2F9CD0F82C9");
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__RaceResu__AFB3C316119BF0B0");

            entity.HasOne(d => d.Driver).WithMany(p => p.RaceResults).HasConstraintName("FK__RaceResul__drive__3F466844");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceResults).HasConstraintName("FK__RaceResul__race___3E52440B");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__F82DEDBC8C4BDA1B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
