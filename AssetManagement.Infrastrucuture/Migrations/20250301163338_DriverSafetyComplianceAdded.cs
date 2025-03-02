using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastrucuture.Migrations
{
    /// <inheritdoc />
    public partial class DriverSafetyComplianceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverSafetyCompliance_Drivers_DriverId",
                table: "DriverSafetyCompliance");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSafetyCompliance_SafetyCriterias_SafetyCriteriaId",
                table: "DriverSafetyCompliance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverSafetyCompliance",
                table: "DriverSafetyCompliance");

            migrationBuilder.RenameTable(
                name: "DriverSafetyCompliance",
                newName: "DriverSafetyCompliances");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSafetyCompliance_SafetyCriteriaId",
                table: "DriverSafetyCompliances",
                newName: "IX_DriverSafetyCompliances_SafetyCriteriaId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSafetyCompliance_DriverId",
                table: "DriverSafetyCompliances",
                newName: "IX_DriverSafetyCompliances_DriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverSafetyCompliances",
                table: "DriverSafetyCompliances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSafetyCompliances_Drivers_DriverId",
                table: "DriverSafetyCompliances",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSafetyCompliances_SafetyCriterias_SafetyCriteriaId",
                table: "DriverSafetyCompliances",
                column: "SafetyCriteriaId",
                principalTable: "SafetyCriterias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverSafetyCompliances_Drivers_DriverId",
                table: "DriverSafetyCompliances");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSafetyCompliances_SafetyCriterias_SafetyCriteriaId",
                table: "DriverSafetyCompliances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverSafetyCompliances",
                table: "DriverSafetyCompliances");

            migrationBuilder.RenameTable(
                name: "DriverSafetyCompliances",
                newName: "DriverSafetyCompliance");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSafetyCompliances_SafetyCriteriaId",
                table: "DriverSafetyCompliance",
                newName: "IX_DriverSafetyCompliance_SafetyCriteriaId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSafetyCompliances_DriverId",
                table: "DriverSafetyCompliance",
                newName: "IX_DriverSafetyCompliance_DriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverSafetyCompliance",
                table: "DriverSafetyCompliance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSafetyCompliance_Drivers_DriverId",
                table: "DriverSafetyCompliance",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSafetyCompliance_SafetyCriterias_SafetyCriteriaId",
                table: "DriverSafetyCompliance",
                column: "SafetyCriteriaId",
                principalTable: "SafetyCriterias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
