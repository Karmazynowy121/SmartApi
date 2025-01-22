using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartTask.Migrations
{
    /// <inheritdoc />
    public partial class RemoveData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Id", "Area", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 50, "PE001", "Type A" },
                    { 2, 100, "PE002", "Type B" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Id", "Code", "Name", "StandardArea" },
                values: new object[,]
                {
                    { 1, "PF001", "Facility A", 1000 },
                    { 2, "PF002", "Facility B", 1500 }
                });
        }
    }
}
