using Microsoft.EntityFrameworkCore;
using StrategyGame.Data.Models;
using System.Reflection;

namespace StrategyGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options)
        {
            
        }

        #region DbSets
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Faction> Factions { get; set; } = null!;
        public virtual DbSet<PlayerFaction> PlayerFactions { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<PlayerBuilding> PlayerBuildings { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<PlayerUnit> PlayerUnits { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<PlayerResource> PlayerResources { get; set; } = null!;
        public virtual DbSet<Battle> Battles { get; set; } = null!;
        public virtual DbSet<BattleUnit> BattleUnits { get; set; } = null!;
        public virtual DbSet<Map> Maps { get; set; } = null!;
        public virtual DbSet<PlayerLocation> PlayerLocations { get; set; } = null!;
        public virtual DbSet<Technology> Technologies { get; set; } = null!;
        public virtual DbSet<PlayerTechnology> PlayerTechnologies { get; set; } = null!;
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=STUDENT24;Database=StrategyGame;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
