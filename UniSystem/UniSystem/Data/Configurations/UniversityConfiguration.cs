using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniSystem.Data.Models;

namespace UniSystem.Data.Configurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasData(SeedUniversities());
        }

        private IEnumerable<University> SeedUniversities()
        {
            var universities = new List<University>()
            {
                new University
                {
                    Id = 1,
                    Name = "National University of Science and Technology"
                },
                new University
                {
                    Id = 2,
                    Name = "International Business and Technology University"
                },
                new University
                {
                    Id = 3,
                    Name = "Global Medical University"
                }
            };

            return universities;
        }
    }
}