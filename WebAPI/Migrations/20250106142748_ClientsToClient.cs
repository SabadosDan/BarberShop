using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ClientsToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Barber_BarberID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Clients_ClientID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Service_ServiceID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Barber_BarberID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Clients_ClientID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Barber_BarberID",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Barber_BarberID",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barber",
                table: "Barber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Barber",
                newName: "Barbers");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Service_BarberID",
                table: "Services",
                newName: "IX_Services_BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_BarberID",
                table: "Schedules",
                newName: "IX_Schedules_BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ClientID",
                table: "Reviews",
                newName: "IX_Reviews_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BarberID",
                table: "Reviews",
                newName: "IX_Reviews_BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ServiceID",
                table: "Appointments",
                newName: "IX_Appointments_ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ClientID",
                table: "Appointments",
                newName: "IX_Appointments_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_BarberID",
                table: "Appointments",
                newName: "IX_Appointments_BarberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barbers",
                table: "Barbers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Barbers_BarberID",
                table: "Appointments",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_ClientID",
                table: "Appointments",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceID",
                table: "Appointments",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Barbers_BarberID",
                table: "Reviews",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Clients_ClientID",
                table: "Reviews",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Barbers_BarberID",
                table: "Schedules",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Barbers_BarberID",
                table: "Services",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Barbers_BarberID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_ClientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Barbers_BarberID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Clients_ClientID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Barbers_BarberID",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Barbers_BarberID",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barbers",
                table: "Barbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Barbers",
                newName: "Barber");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Services_BarberID",
                table: "Service",
                newName: "IX_Service_BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_BarberID",
                table: "Schedule",
                newName: "IX_Schedule_BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ClientID",
                table: "Review",
                newName: "IX_Review_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BarberID",
                table: "Review",
                newName: "IX_Review_BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceID",
                table: "Appointment",
                newName: "IX_Appointment_ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientID",
                table: "Appointment",
                newName: "IX_Appointment_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_BarberID",
                table: "Appointment",
                newName: "IX_Appointment_BarberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barber",
                table: "Barber",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Barber_BarberID",
                table: "Appointment",
                column: "BarberID",
                principalTable: "Barber",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Clients_ClientID",
                table: "Appointment",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Service_ServiceID",
                table: "Appointment",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Barber_BarberID",
                table: "Review",
                column: "BarberID",
                principalTable: "Barber",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Clients_ClientID",
                table: "Review",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Barber_BarberID",
                table: "Schedule",
                column: "BarberID",
                principalTable: "Barber",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Barber_BarberID",
                table: "Service",
                column: "BarberID",
                principalTable: "Barber",
                principalColumn: "ID");
        }
    }
}
