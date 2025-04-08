using Microsoft.EntityFrameworkCore;
using UniSystem.Data;
using UniSystem.Data.Models;
using UniSystem.Data.DTOs;

namespace UniSystem.Controllers
{
    public class FacultyController(UniversityDbContext context)
    {
        public async Task AddFaculty(string name, int uniId)
        {
            await context.AddAsync(new Faculty
            {
                Name = name,
                UniversityId = uniId
            });

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FacultyDTO>> GetFacultiesByUniversityId(int uniId)
        {
            return await context.Faculties
                .Where(f => f.UniversityId == uniId)
                .Select(f => new FacultyDTO
                {
                    FacultyName = f.Name,
                    UniName = f.University.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<FacultyDTO>> GetFacultiesByName(string name)
        {
            return await context.Faculties
                .Where(f => f.Name == name)
                .Select(f => new FacultyDTO
                {
                    FacultyName = f.Name,
                    UniName = f.University.Name
                })
                .ToListAsync();
        }

        public async Task<FacultyDTO?> GetFacultyByNameAndUniversityId(string name, int uniId)
        {
            return await context.Faculties
                .Where(f => f.UniversityId == uniId && f.Name == name)
                .Select(f => new FacultyDTO
                {
                    FacultyName = f.Name,
                    UniName = f.University.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
