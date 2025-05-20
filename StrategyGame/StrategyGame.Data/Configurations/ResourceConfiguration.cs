using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrategyGame.Data.Models;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        var json = File.ReadAllText("../StrategyGame.Data/Seed/Resources.json");
        var resources = JsonSerializer.Deserialize<List<Resource>>(json)!;
        builder.HasData(resources);
    }
}