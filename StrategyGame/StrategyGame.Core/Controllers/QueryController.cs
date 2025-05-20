using Microsoft.EntityFrameworkCore;
using StrategyGame.Data;
using StrategyGame.Core.ViewModels;

namespace StrategyGame.Core.Controllers
{
    public class QueryController(ApplicationDbContext context)
    {

        public async Task<List<PlayerWithResourcesViewModel>> GetPlayersWithResourcesAsync()
        {
            return await context.Players
                .Select(p => new PlayerWithResourcesViewModel
                {
                    Username = p.Username,
                    Resources = p.PlayerResources
                        .Select(r => new ResourceAmountViewModel
                        {
                            ResourceName = r.Resource.Name,
                            Amount = r.Amount
                        }).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<BattleResultViewModel>> GetLatestBattlesAsync()
        {
            return await context.Battles
                .OrderByDescending(b => b.StartedAt)
                .Take(5)
                .Select(b => new BattleResultViewModel
                {
                    Attacker = b.Attacker.Username,
                    Defender = b.Defender.Username,
                    StartedAt = b.StartedAt,
                    EndedAt = b.EndedAt,
                    Result = b.Result.ToString()
                })
                .ToListAsync();
        }

        public async Task<FactionDetailsViewModel?> GetHumansFactionDetailsAsync()
        {
            var faction = await context.Factions
                .Include(f => f.Buildings)
                .Include(f => f.Units)
                .FirstOrDefaultAsync(f => f.Name == "Humans");

            if (faction == null) return null;

            return new FactionDetailsViewModel
            {
                FactionName = faction.Name,
                Buildings = faction.Buildings.Select(b => b.Name).ToList(),
                Units = faction.Units.Select(u => u.Name).ToList()
            };
        }
    }
}