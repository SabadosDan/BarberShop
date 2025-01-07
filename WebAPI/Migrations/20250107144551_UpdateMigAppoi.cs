using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigAppoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Appointment_AppointmentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_AppointmentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppointmentId",
                table: "Services",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Appointment_AppointmentId",
                table: "Services",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");
        }
    }
}
