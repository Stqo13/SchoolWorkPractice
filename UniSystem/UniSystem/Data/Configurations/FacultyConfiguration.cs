using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniSystem.Data.Models;

namespace UniSystem.Data.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasData(SeedFaculties());
        }

        private IEnumerable<Faculty> SeedFaculties()
        {
            var faculties = new List<Faculty>()
            {
                new Faculty
                {
                    Id = 1,
                    Name = "Faculty of Engineering",
                    UniversityId = 1
                },
                new Faculty
                {
                    Id = 2,
                    Name = "Faculty of Arts and Humanities",
                    UniversityId = 1
                },
                new Faculty
                {
                    Id = 3,
                    Name = "Faculty of Business and Economics",
                    UniversityId = 2
                },
                new Faculty
                {
                    Id = 4,
                    Name = "Faculty of Medicine",
                    UniversityId = 3
                },
                new Faculty
                {
                    Id = 5,
                    Name = "Faculty of Computer Science",
                    UniversityId = 2
                }
            };

            return faculties;
        }
    }
}