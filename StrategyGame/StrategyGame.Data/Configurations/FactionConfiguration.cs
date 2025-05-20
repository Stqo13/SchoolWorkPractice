using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Data.Models;

public class FactionConfiguration : IEntityTypeConfiguration<Faction>
{
    public void Configure(EntityTypeBuilder<Faction> builder)
    {
        var json = File.ReadAllText("../StrategyGame.Data/Seed/Factions.json");
        var factions = JsonSerializer.Deserialize<List<Faction>>(json)!;
        builder.HasData(factions);
    }
}