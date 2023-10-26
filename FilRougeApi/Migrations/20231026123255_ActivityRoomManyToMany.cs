using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeApi.Migrations
{
    /// <inheritdoc />
    public partial class ActivityRoomManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Rooms_RoomId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RoomId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "ActivityRoom",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityRoom", x => new { x.ActivitiesId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_ActivityRoom_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "0101010101");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "0202020202");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityRoom_RoomsId",
                table: "ActivityRoom",
                column: "RoomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityRoom");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "01 01 01 01 01");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "02 02 02 02 02");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RoomId",
                table: "Activities",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Rooms_RoomId",
                table: "Activities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
