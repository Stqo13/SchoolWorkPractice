using StrategyGame.Core.Controllers;
using StrategyGame.Data;
using StrategyGame.Views;

namespace StrategyGame
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            QueryController controller = new QueryController(context);

            Menu menu = new Menu(context, controller);

            await menu.ShowMainMenuAsync();
        }
    }
}
