using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gameStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    releaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameStateId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_gameStates_GameStateId",
                        column: x => x.GameStateId,
                        principalTable: "gameStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "yousef", "123" },
                    { 2, "ali", "234" },
                    { 3, "hi", "345" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pc" },
                    { 2, "Console" },
                    { 3, "Playstation" }
                });

            migrationBuilder.InsertData(
                table: "gameStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Released" },
                    { 2, "EarlyAccess" },
                    { 3, "Upcoming" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameStateId", "PlatformId", "name", "releaseDate", "src" },
                values: new object[,]
                {
                    { 1, 1, 1, "Overwatch", "12/2", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp" },
                    { 2, 2, 2, "Overwatch", "12/2", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp" },
                    { 3, 3, 3, "Overwatch", "12/2", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp" },
                    { 4, 3, 1, "Heroes of the storm", "12/2", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltce07525c7490946d/61a50fc22e73ff101cdc1c8d/heroes.jpg?format=webply&quality=80&auto=webp" },
                    { 5, 2, 2, "Starcraft II", "12/2", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/blt3873027b9450f357/61a50f033c4e21100a80f1fc/starcraft2.jpg?format=webply&quality=80&auto=webp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameStateId",
                table: "Games",
                column: "GameStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformId",
                table: "Games",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "gameStates");
        }
    }
}
