using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FourthTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FourthTask");

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "FourthTask",
                columns: table => new
                {
                    AreaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "MarkersCoordinates",
                schema: "FourthTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkersCoordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreasCoordinates",
                schema: "FourthTask",
                columns: table => new
                {
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    AreaCoordinateId = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasCoordinates", x => new { x.AreaId, x.AreaCoordinateId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_AreasCoordinates_Areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "FourthTask",
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "FourthTask",
                table: "Areas",
                columns: new[] { "AreaId", "AreaName" },
                values: new object[] { 1L, "Area 1" });

            migrationBuilder.InsertData(
                schema: "FourthTask",
                table: "MarkersCoordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "PointName" },
                values: new object[,]
                {
                    { 1L, 55.160503714821843, 61.370177583057185, "SUSU" },
                    { 2L, 55.166862645697776, 61.40195476957598, "Chelyabinsk State Academic Opera and Ballet Theater" },
                    { 3L, 55.16834771226128, 61.398008203174214, "Chelyabinsk State Museum of Local Lore" },
                    { 4L, 55.156242835103313, 61.402826352874968, "Chelyabinsk State Academic Drama Theater" },
                    { 5L, 55.162534668869498, 61.391016876126002, "Turbo plane" }
                });

            migrationBuilder.InsertData(
                schema: "FourthTask",
                table: "AreasCoordinates",
                columns: new[] { "AreaCoordinateId", "AreaId", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1L, 1L, 55.160594029458032, 61.388364441936567 },
                    { 2L, 1L, 55.161587503740748, 61.393122292291253 },
                    { 3L, 1L, 55.158790849924642, 61.391890341658154 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AreaName",
                schema: "FourthTask",
                table: "Areas",
                column: "AreaName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarkersCoordinates_PointName",
                schema: "FourthTask",
                table: "MarkersCoordinates",
                column: "PointName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasCoordinates",
                schema: "FourthTask");

            migrationBuilder.DropTable(
                name: "MarkersCoordinates",
                schema: "FourthTask");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "FourthTask");
        }
    }
}
