using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniSystem.Data.Models;

namespace UniSystem.Data.Configurations
{
    public class MajorConfiguration : IEntityTypeConfiguration<Major>
    {
        public void Configure(EntityTypeBuilder<Major> builder)
        {
            builder.HasData(SeedMajors());
        }

        private IEnumerable<Major> SeedMajors()
        {
            var majors = new List<Major>()
            {
                new Major
                {
                    Id = 1,
                    Name = "Mechanical Engineering",
                    FacultyId = 1
                },
                new Major
                {
                    Id = 2,
                    Name = "English Literature",
                    FacultyId = 2
                },
                new Major
                {
                    Id = 3,
                    Name = "Accounting",
                    FacultyId = 3
                },
                new Major
                {
                    Id = 4,
                    Name = "Internal Medicine",
                    FacultyId = 4
                },
                new Major
                {
                    Id = 5,
                    Name = "Software Engineering",
                    FacultyId = 5
                }
            };

            return majors;
        }
    }
}
