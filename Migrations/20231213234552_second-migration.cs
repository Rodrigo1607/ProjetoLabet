using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModeloExame",
                table: "Paciente");

            migrationBuilder.CreateTable(
                name: "ModeloExame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeExame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorLeucocitos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPlaquetas = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloExame", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloExame");

            migrationBuilder.AddColumn<int>(
                name: "ModeloExame",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
