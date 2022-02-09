using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaylistsApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearReleased = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Album", "Artist", "Title", "YearReleased" },
                values: new object[] { 1, "12 Inch Single", "New Order", "Blue Monday", 1983 });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Album", "Artist", "Title", "YearReleased" },
                values: new object[] { 2, null, "Europe", "The Final Countdown", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
