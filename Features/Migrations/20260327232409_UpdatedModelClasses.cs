using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Features.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CopyOptions",
                columns: table => new
                {
                    CopyOptionsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Overwrite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Recursive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateParentDirectory = table.Column<bool>(type: "INTEGER", nullable: false),
                    InputPath = table.Column<string>(type: "TEXT", nullable: false),
                    OutputPath = table.Column<string>(type: "TEXT", nullable: false),
                    Action = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopyOptions", x => x.CopyOptionsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopyOptions");
        }
    }
}
