namespace UniSystem.Data.DTOs
{
    public class UniDTO
    {
        public string UniName { get; set; } = null!;

        public IEnumerable<string> FacultyNames { get; set; } = new List<string>();
    }
}
