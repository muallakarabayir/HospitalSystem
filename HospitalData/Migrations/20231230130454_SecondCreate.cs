using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalData.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliclinicId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PoliclinicId",
                table: "Appointments",
                column: "PoliclinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Policlinics_PoliclinicId",
                table: "Appointments",
                column: "PoliclinicId",
                principalTable: "Policlinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Policlinics_PoliclinicId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PoliclinicId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PoliclinicId",
                table: "Appointments");
        }
    }
}
