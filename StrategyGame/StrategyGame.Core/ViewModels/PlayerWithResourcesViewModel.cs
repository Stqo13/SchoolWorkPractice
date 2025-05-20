namespace StrategyGame.Core.ViewModels
{
    public class PlayerWithResourcesViewModel
    {
        public string Username { get; set; } = null!;
        public List<ResourceAmountViewModel> Resources { get; set; } = [];
    }
}