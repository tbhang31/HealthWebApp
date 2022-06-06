using Microsoft.EntityFrameworkCore.Migrations;

namespace liftoffHealthCare.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VitalMedications",
                columns: table => new
                {
                    VitalId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalMedications", x => new { x.VitalId, x.MedicationId });
                    table.ForeignKey(
                        name: "FK_VitalMedications_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VitalMedications_Vitals_VitalId",
                        column: x => x.VitalId,
                        principalTable: "Vitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VitalMedications_MedicationId",
                table: "VitalMedications",
                column: "MedicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VitalMedications");
        }
    }
}
