using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectT1.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
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
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.IdModelo);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstPer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "IdModelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "IdMarca", "NomMarca" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Ford" },
                    { 3, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "IdModelo", "MarcaId", "NomModelo" },
                values: new object[,]
                {
                    { 1, 1, "Camry" },
                    { 2, 1, "Corolla" },
                    { 3, 1, "RAV4" },
                    { 4, 2, "Focus" },
                    { 5, 2, "Mustang" },
                    { 6, 2, "Explorer" },
                    { 7, 3, "Civic" },
                    { 8, 3, "Accord" },
                    { 9, 3, "CR-V" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculo",
                columns: new[] { "IdVehiculo", "Anio", "Color", "EstPer", "ModeloId", "NroPlaca" },
                values: new object[,]
                {
                    { 1, 2021, "Rojo", "Optimo", 1, "ABC-1234" },
                    { 2, 2022, "Azul", "Bueno", 2, "MNO-3141" },
                    { 3, 2023, "Amarillo", "Caducado", 3, "JKL-1121" },
                    { 4, 2024, "Rosado", "Buenas Condiciones ", 4, "GHI-9101" },
                    { 5, 2025, "Verde", "Malo", 5, "XYZ-5678" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaId",
                table: "Modelo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ModeloId",
                table: "Vehiculo",
                column: "ModeloId");
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
