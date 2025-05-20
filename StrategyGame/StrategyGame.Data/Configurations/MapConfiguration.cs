using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Data.Models;

public class MapConfiguration : IEntityTypeConfiguration<Map>
{
    public void Configure(EntityTypeBuilder<Map> builder)
    {
        var json = File.ReadAllText("../StrategyGame.Data/Seed/Maps.json");
        var maps = JsonSerializer.Deserialize<List<Map>>(json)!;
        builder.HasData(maps);
    }
}