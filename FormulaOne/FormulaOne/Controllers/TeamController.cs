using Microsoft.EntityFrameworkCore;
using FormulaOne.Data;
using FormulaOne.Controllers.DTOs.TeamDTOs;

namespace FormulaOne.Controllers
{
    public class TeamController
    {
        private readonly FormulaOneDbContext context = new();

        public async Task<IEnumerable<AllTeamsInfo>> GetAllTeamsAsync()
        {
            var teams = await context.Teams
                .Select(t => new AllTeamsInfo
                {
                    Name = t.TeamName,
                    Country = t.Country,
                    FoundationYear = t.FoundationYear
                })
                .ToListAsync();

            return teams;
        }

        public async Task<TeamInfo> GetTeamByIdAsync(int id)
        {
            var entity = await context.Teams
                .FindAsync(id);

            if (entity is null)
            {
                throw new NullReferenceException("Entity was null!");
            }

            var team = new TeamInfo
            {
                Name = entity.TeamName,
                Country = entity.Country,
                FoundationYear = entity.FoundationYear
            };

            return team;
        }

        public async Task<IEnumerable<AllTeamsInfo>> GetTeamsByCountryAsync(string country)
        {
            var teams = await context.Teams
                .Where(t => t.Country == country)
                .Select(t => new AllTeamsInfo
                {
                    Name = t.TeamName,
                    Country = t.Country,
                    FoundationYear = t.FoundationYear
                })
                .ToListAsync();

            return teams;
        }

        public async Task<TeamInfo> GetOldestTeamAsync()
        {
            var entity = await context.Teams
                .OrderBy(t => t.FoundationYear)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                throw new NullReferenceException("Entity was null!");
            }

            var team = new TeamInfo
            {
                Name = entity.TeamName,
                Country = entity.Country,
                FoundationYear= entity.FoundationYear
            };

            return team;
        }
    }
}
