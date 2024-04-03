using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabla1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Campo2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Campo3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tabla1Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabla1_Tabla1_Tabla1Id",
                        column: x => x.Tabla1Id,
                        principalTable: "Tabla1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tabla2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Campo2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Campo3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabla3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Campo2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Campo3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla3", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabla1_Tabla1Id",
                table: "Tabla1",
                column: "Tabla1Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabla1");

            migrationBuilder.DropTable(
                name: "Tabla2");

            migrationBuilder.DropTable(
                name: "Tabla3");
        }
    }
}
