using Microsoft.EntityFrameworkCore;
using UniSystem.Data;
using UniSystem.Data.Models;
using UniSystem.Data.DTOs;

namespace UniSystem.Controllers
{
    public class MajorController(UniversityDbContext context)
    {
        public async Task AddMajor(string name, int facultyId)
        {
            await context.AddAsync(new Major
            {
                Name = name,
                FacultyId = facultyId
            });

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MajorDTO>> GetMajorsByFacultyId(int facultyId)
        {
            return await context.Majors
                .Where(m => m.FacultyId == facultyId)
                .Select(m => new MajorDTO
                {
                    MajorName = m.Name,
                    FacultyName = m.Faculty.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MajorDTO>> GetMajorsByName(string name)
        {
            return await context.Majors
                .Where(m => m.Name == name)
                .Select(m => new MajorDTO
                {
                    MajorName = name,
                    FacultyName = m.Faculty.Name
                })
                .ToListAsync();
        }

        public async Task<MajorDTO?> GetMajorByNameAndFacultyId(string name, int facultyId)
        {
            return await context.Majors
                .Where(m => m.FacultyId == facultyId && m.Name == name)
                .Select(m => new MajorDTO
                {
                    MajorName = name,
                    FacultyName = m.Faculty.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
