using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UniSystem.Data.Models;

namespace UniSystem.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
        {
                
        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
                : base(options)
        {
            
        }

        public virtual DbSet<University> Universities { get; set; }

        public virtual DbSet<Major> Majors { get; set; }

        public virtual DbSet<Faculty> Faculties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=STUDENT24;Database=University;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
