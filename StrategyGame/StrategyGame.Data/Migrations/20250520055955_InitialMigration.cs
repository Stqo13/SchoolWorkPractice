using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StrategyGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeY = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearchTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildTime = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackPower = table.Column<int>(type: "int", nullable: false),
                    DefensePower = table.Column<int>(type: "int", nullable: false),
                    TrainingTime = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackerId = table.Column<int>(type: "int", nullable: false),
                    DefenderId = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Players_AttackerId",
                        column: x => x.AttackerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Battles_Players_DefenderId",
                        column: x => x.DefenderId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerFactions",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFactions", x => new { x.PlayerId, x.FactionId });
                    table.ForeignKey(
                        name: "FK_PlayerFactions_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerFactions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLocations",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLocations", x => new { x.PlayerId, x.MapId });
                    table.ForeignKey(
                        name: "FK_PlayerLocations_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerLocations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerResources",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerResources", x => new { x.PlayerId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_PlayerResources_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTechnologies",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsResearched = table.Column<bool>(type: "bit", nullable: false),
                    ResearchedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTechnologies", x => new { x.PlayerId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_PlayerTechnologies_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBuildings",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBuildings", x => new { x.PlayerId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_PlayerBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerBuildings_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerUnits",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerUnits", x => new { x.PlayerId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_PlayerUnits_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BattleUnits",
                columns: table => new
                {
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleUnits", x => new { x.BattleId, x.UnitId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_BattleUnits_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BattleUnits_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BattleUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Factions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Balanced race with strong economy.", "Humans" },
                    { 2, "Strong melee units, weak defenses.", "Orcs" }
                });

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "Description", "Name", "SizeX", "SizeY" },
                values: new object[] { 1, "A balanced map with hills and forests.", "Valley of Kings", 100, 100 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Used for building and training.", "Gold" },
                    { 2, "Required for units to survive.", "Food" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Description", "Name", "ResearchTime" },
                values: new object[,]
                {
                    { 1, "Increases attack by 10%", "Advanced Metallurgy", 120 },
                    { 2, "Increases food production by 20%", "Efficient Farming", 90 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "BuildTime", "Description", "FactionId", "Name" },
                values: new object[,]
                {
                    { 1, 60, "Trains infantry.", 1, "Barracks" },
                    { 2, 30, "Produces food.", 1, "Farm" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackPower", "DefensePower", "FactionId", "Name", "TrainingTime" },
                values: new object[,]
                {
                    { 1, 10, 5, 1, "Swordsman", 45 },
                    { 2, 7, 3, 1, "Archer", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_AttackerId",
                table: "Battles",
                column: "AttackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_DefenderId",
                table: "Battles",
                column: "DefenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleUnits_PlayerId",
                table: "BattleUnits",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleUnits_UnitId",
                table: "BattleUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_FactionId",
                table: "Buildings",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBuildings_BuildingId",
                table: "PlayerBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFactions_FactionId",
                table: "PlayerFactions",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLocations_MapId",
                table: "PlayerLocations",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResources_ResourceId",
                table: "PlayerResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTechnologies_TechnologyId",
                table: "PlayerTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerUnits_UnitId",
                table: "PlayerUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleUnits");

            migrationBuilder.DropTable(
                name: "PlayerBuildings");

            migrationBuilder.DropTable(
                name: "PlayerFactions");

            migrationBuilder.DropTable(
                name: "PlayerLocations");

            migrationBuilder.DropTable(
                name: "PlayerResources");

            migrationBuilder.DropTable(
                name: "PlayerTechnologies");

            migrationBuilder.DropTable(
                name: "PlayerUnits");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}
