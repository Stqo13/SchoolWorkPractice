using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Data.Models;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        var json = File.ReadAllText("../StrategyGame.Data/Seed/Units.json");
        var units = JsonSerializer.Deserialize<List<Unit>>(json)!;
        builder.HasData(units);
    }
}