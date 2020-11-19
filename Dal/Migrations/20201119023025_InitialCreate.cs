using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Cod = table.Column<string>(nullable: false),
                    PersonaId = table.Column<string>(nullable: true),
                    TipoPago = table.Column<string>(nullable: true),
                    FechaPago = table.Column<string>(nullable: true),
                    ValorPago = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false),
                    PagoTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Cod);
                    table.ForeignKey(
                        name: "FK_Pago_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pago_PersonaId",
                table: "Pago",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
