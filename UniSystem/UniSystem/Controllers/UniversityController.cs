using Microsoft.EntityFrameworkCore;
using UniSystem.Data;
using UniSystem.Data.Models;
using UniSystem.Data.DTOs;

namespace UniSystem.Controllers
{
    public class UniversityController(UniversityDbContext context)
    {
        public async Task AddUniversity(string name)
        {
            await context.AddAsync(new University
            {
                Name = name
            });

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UniDTO>> GetAllUniversities()
        {
            var universities = await context.Universities
                .Select(u => new UniDTO
                {
                    UniName = u.Name,
                    FacultyNames = u.Faculties.Select(f => f.Name)
                })
                .ToListAsync();

            return universities;
        }

        public async Task<UniDTO?> GetUniversityByName(string name)
        {
            return await context.Universities
               .Where(u => u.Name == name)
               .Select(u => new UniDTO
               {
                   UniName = name,
                   FacultyNames = u.Faculties.Select(f => f.Name)
               })
               .FirstOrDefaultAsync();
        }

        public async Task<int?> GetUniversityIdByName(string name)
        {
            return await context.Universities
                .Where(u => u.Name == name)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
        }
    }
}
