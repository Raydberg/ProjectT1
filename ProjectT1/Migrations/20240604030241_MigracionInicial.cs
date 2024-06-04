using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectT1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMarca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    IdModelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: true),
                    MarcaIdMarca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.IdModelo);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_MarcaIdMarca",
                        column: x => x.MarcaIdMarca,
                        principalTable: "Marca",
                        principalColumn: "IdMarca");
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdModelo = table.Column<int>(type: "int", nullable: false),
                    ModeloIdModelo = table.Column<int>(type: "int", nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstPer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Modelo_ModeloIdModelo",
                        column: x => x.ModeloIdModelo,
                        principalTable: "Modelo",
                        principalColumn: "IdModelo");
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "IdMarca", "NomMarca" },
                values: new object[,]
                {
                    { 1, "Marca1" },
                    { 2, "Marca2" },
                    { 3, "Marca3" },
                    { 4, "Marca4" },
                    { 5, "Marca5" }
                });

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "IdModelo", "IdMarca", "MarcaIdMarca", "NomModelo" },
                values: new object[,]
                {
                    { 1, 1, null, "Modelo1" },
                    { 2, 2, null, "Modelo2" },
                    { 3, 3, null, "Modelo3" },
                    { 4, 4, null, "Modelo4" },
                    { 5, 5, null, "Modelo5" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculo",
                columns: new[] { "IdVehiculo", "Anio", "Color", "EstPer", "IdModelo", "ModeloIdModelo", "NroPlaca" },
                values: new object[,]
                {
                    { 1, 2021, "Rojo", "Bueno", 1, null, "Placa1" },
                    { 2, 2022, "Azul", "Excelente", 2, null, "Placa2" },
                    { 3, 2023, "Amarillo", "Regular", 3, null, "Placa3" },
                    { 4, 2024, "Rosado", "Optimo", 4, null, "Placa4" },
                    { 5, 2025, "Verde", "Pesimo", 5, null, "Placa5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaIdMarca",
                table: "Modelo",
                column: "MarcaIdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ModeloIdModelo",
                table: "Vehiculo",
                column: "ModeloIdModelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
