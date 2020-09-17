using Microsoft.EntityFrameworkCore.Migrations;

namespace ddSpelunker.Cmd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiskDrives",
                columns: table => new
                {
                    DiskDriveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskDrives", x => x.DiskDriveId);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    NuggetFileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    DiskDriveId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.NuggetFileId);
                    table.ForeignKey(
                        name: "FK_Files_DiskDrives_DiskDriveId",
                        column: x => x.DiskDriveId,
                        principalTable: "DiskDrives",
                        principalColumn: "DiskDriveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_DiskDriveId",
                table: "Files",
                column: "DiskDriveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "DiskDrives");
        }
    }
}
