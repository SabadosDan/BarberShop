using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class MultipleSelectionOnAppont : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Services_ServiceId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_ServiceId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ServiceId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceId",
                table: "Appointment",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Services_ServiceId",
                table: "Appointment",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
