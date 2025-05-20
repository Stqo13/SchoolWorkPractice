using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Models;

namespace MoneyQuiz.Data
{
    public class MoneyQuizDbContext : DbContext
    {
        public MoneyQuizDbContext()
        {
                
        }

        public MoneyQuizDbContext(DbContextOptions<MoneyQuizDbContext> options)
            :base(options)
        {
                
        }

        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<GameSession> GamesSessions { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerAnswer> PlayersAnswers { get; set; } = null!;
        public DbSet<PlayerGameSession> PlayersGameSessions { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
