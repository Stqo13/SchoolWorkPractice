namespace FormulaOne.Controllers.DTOs.TeamDTOs
{
    public class TeamInfo
    {
        public required string Name { get; set; } = null!;

        public required string Country { get; set; } = null!;

        public required int FoundationYear { get; set; }
    }
}
