using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Data.Models;

public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        var json = File.ReadAllText("../StrategyGame.Data/Seed/Technologies.json");
        var techs = JsonSerializer.Deserialize<List<Technology>>(json)!;
        builder.HasData(techs);
    }
}