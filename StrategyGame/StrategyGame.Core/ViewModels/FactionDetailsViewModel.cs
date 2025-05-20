namespace StrategyGame.Core.ViewModels
{
    public class FactionDetailsViewModel
    {
        public string FactionName { get; set; } = null!;
        public List<string> Buildings { get; set; } = [];
        public List<string> Units { get; set; } = [];
    }
}