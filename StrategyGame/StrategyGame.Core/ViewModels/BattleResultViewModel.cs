namespace StrategyGame.Core.ViewModels
{
    public class BattleResultViewModel
    {
        public string Attacker { get; set; } = null!;
        public string Defender { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string Result { get; set; } = null!;
    }
}