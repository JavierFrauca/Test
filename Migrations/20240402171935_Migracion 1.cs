using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST.Migrations
{
    /// <inheritdoc />
    public partial class Migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabla1_Tabla1_Tabla1Id",
                table: "Tabla1");

            migrationBuilder.DropIndex(
                name: "IX_Tabla1_Tabla1Id",
                table: "Tabla1");

            migrationBuilder.DropColumn(
                name: "Tabla1Id",
                table: "Tabla1");

            migrationBuilder.AlterColumn<string>(
                name: "Campo3",
                table: "Tabla2",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Campo2",
                table: "Tabla2",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Campo1",
                table: "Tabla2",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Tabla2",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campo3",
                table: "Tabla1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Campo2",
                table: "Tabla1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Campo1",
                table: "Tabla1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Tabla2_OriginId",
                table: "Tabla2",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla2_Tabla1_OriginId",
                table: "Tabla2",
                column: "OriginId",
                principalTable: "Tabla1",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabla2_Tabla1_OriginId",
                table: "Tabla2");

            migrationBuilder.DropIndex(
                name: "IX_Tabla2_OriginId",
                table: "Tabla2");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Tabla2");

            migrationBuilder.AlterColumn<string>(
                name: "Campo3",
                table: "Tabla2",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campo2",
                table: "Tabla2",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campo1",
                table: "Tabla2",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campo3",
                table: "Tabla1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campo2",
                table: "Tabla1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campo1",
                table: "Tabla1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tabla1Id",
                table: "Tabla1",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tabla1_Tabla1Id",
                table: "Tabla1",
                column: "Tabla1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla1_Tabla1_Tabla1Id",
                table: "Tabla1",
                column: "Tabla1Id",
                principalTable: "Tabla1",
                principalColumn: "Id");
        }
    }
}
