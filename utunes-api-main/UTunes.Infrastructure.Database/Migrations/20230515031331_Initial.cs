using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTunes.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "Id", "Artist", "Name", "Review" },
                values: new object[] { 1, "Backstreet Boys", "DNA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean sed leo elit. Nullam tellus ipsum, fringilla quis ex vitae, mattis rutrum felis. Duis venenatis faucibus turpis, at tincidunt arcu bibendum ac. Vestibulum eget placerat libero, nec tempus ipsum. Sed elit libero, luctus non dapibus et, sagittis a tellus. Ut suscipit porta vestibulum. Mauris justo velit, pretium at efficitur nec, posuere non massa. Proin quis aliquet quam. Maecenas malesuada mauris ex, eu sollicitudin quam laoreet ut. Sed mollis enim dolor, eu malesuada dui aliquet ut. Quisque rhoncus augue urna, at volutpat justo ultrices et. Vivamus maximus quam non nisl placerat varius. Nam mollis erat ullamcorper diam efficitur, molestie feugiat urna finibus. Phasellus dignissim interdum neque sed dictum." });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "AlbumId", "Artist", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Backstreet boys", "Don't go breaking my heart" },
                    { 2, 1, "Backstreet boys", "Nobody else" },
                    { 3, 1, "Backstreet boys", "Breathe" },
                    { 4, 1, "Backstreet boys", "New love" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Album");
        }
    }
}
