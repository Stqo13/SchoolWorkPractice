using StrategyGame.Data;
using StrategyGame.Core.Controllers;

namespace StrategyGame.Views
{
    public class Menu(
        ApplicationDbContext context,
        QueryController queryController)
    {
        public async Task ShowMainMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Strategy Game Menu ===");
                Console.WriteLine("1. Show all players with their resources");
                Console.WriteLine("2. Show latest 5 battles");
                Console.WriteLine("3. Show buildings and units for 'Humans'");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        var players = await queryController.GetPlayersWithResourcesAsync();
                        foreach (var player in players)
                        {
                            Console.WriteLine($"Player: {player.Username}");
                            foreach (var res in player.Resources)
                            {
                                Console.WriteLine($"  - {res.ResourceName}: {res.Amount}");
                            }
                        }
                        break;

                    case "2":
                        var battles = await queryController.GetLatestBattlesAsync();
                        foreach (var battle in battles)
                        {
                            Console.WriteLine($"Battle: {battle.Attacker} vs {battle.Defender}");
                            Console.WriteLine($"  Started: {battle.StartedAt}, Ended: {battle.EndedAt}");
                            Console.WriteLine($"  Result: {battle.Result}");
                        }
                        break;

                    case "3":
                        var faction = await queryController.GetHumansFactionDetailsAsync();
                        if (faction == null)
                        {
                            Console.WriteLine("Faction 'Humans' not found.");
                        }
                        else
                        {
                            Console.WriteLine($"Faction: {faction.FactionName}");
                            Console.WriteLine("Buildings:");
                            faction.Buildings.ForEach(b => Console.WriteLine($"  - {b}"));
                            Console.WriteLine("Units:");
                            faction.Units.ForEach(u => Console.WriteLine($"  - {u}"));
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }
}
