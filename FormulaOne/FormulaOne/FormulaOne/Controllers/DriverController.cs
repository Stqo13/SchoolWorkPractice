#nullable disable

using Microsoft.EntityFrameworkCore;
using FormulaOne.Data;
using FormulaOne.Controllers.DTOs.DriverDTOs;

namespace FormulaOne.Controllers
{
    public class DriverController
    {
        private readonly FormulaOneDbContext context = new();

        private const string DateTimeFormat = "yyyy-MM-dd";

        public async Task<IEnumerable<AllDriversInfo>> GetAllDriversAsync()
        {
            var drivers = await context.Drivers
                .Select(d => new AllDriversInfo 
                {
                    FullName = $"{d.FirstName} {d.LastName}",
                    BirthDate = d.BirthDate.ToString(DateTimeFormat),
                    Nationality = d.Nationality,
                    TeamName = d.Team.TeamName
                })
                .ToListAsync();

            return drivers;
        }

        public async Task<DriverInfo> GetDriverByIdAsync(int id)
        {
            var entity = await context.Drivers
                .FindAsync(id);

            if (entity is null)
            {
                throw new NullReferenceException("Entity was null!");
            }

            var driver = new DriverInfo
            {
                FullName = $"{entity.FirstName} {entity.LastName}",
                BirthDate = entity.BirthDate.ToString(DateTimeFormat),
                Nationality = entity.Nationality,
                TeamName = entity.Team.TeamName
            };

            return driver;
        }

        public async Task<IEnumerable<AllDriversInfo>> GetDriversByLastNameAsync(string lastName)
        {
            var driver = await context.Drivers
                .Where(d => d.LastName == lastName)
                .Select(d => new AllDriversInfo
                {
                    FullName = $"{d.FirstName} {d.LastName}",
                    BirthDate = d.BirthDate.ToString(DateTimeFormat),
                    Nationality = d.Nationality,
                    TeamName = d.Team.TeamName
                })
                .ToListAsync();

            return driver;
        }

        public async Task<IEnumerable<AllDriversInfo>> GetDriversByNationalityAsync(string nationality)
        {
            var drivers = await context.Drivers
                .Where(d => d.Nationality == nationality)
                .Select(d => new AllDriversInfo
                {
                    FullName = $"{d.FirstName} {d.LastName}",
                    BirthDate = d.BirthDate.ToString(DateTimeFormat),
                    Nationality = d.Nationality,
                    TeamName = d.Team.TeamName
                })
                .ToListAsync();

            return drivers;
        }
    }
}
