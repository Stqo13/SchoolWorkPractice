using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Data.Models;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        var json = File.ReadAllText("../StrategyGame.Data/Seed/Buildings.json");
        var buildings = JsonSerializer.Deserialize<List<Building>>(json)!;
        builder.HasData(buildings);
    }
}