using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceptoinSystemAppWAD.Data.Migrationa
{
    public partial class ReservationRoomNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomStatus",
                table: "Rooms",
                newName: "RoomNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNum",
                table: "Rooms",
                newName: "RoomStatus");
        }
    }
}
