using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilRougeApi.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityRoom_Activities_ActivitiesId",
                table: "ActivityRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityRoom_Rooms_RoomsId",
                table: "ActivityRoom");

            migrationBuilder.DropTable(
                name: "SessionUser");

            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "ActivityRoom",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "ActivitiesId",
                table: "ActivityRoom",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityRoom_RoomsId",
                table: "ActivityRoom",
                newName: "IX_ActivityRoom_RoomId");

            migrationBuilder.CreateTable(
                name: "SessionsUser",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionsUser", x => new { x.SessionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SessionsUser_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionsUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityRoom",
                columns: new[] { "ActivityId", "RoomId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "SessionsUser",
                columns: new[] { "SessionId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionsUser_UserId",
                table: "SessionsUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityRoom_Activities_ActivityId",
                table: "ActivityRoom",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityRoom_Rooms_RoomId",
                table: "ActivityRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityRoom_Activities_ActivityId",
                table: "ActivityRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityRoom_Rooms_RoomId",
                table: "ActivityRoom");

            migrationBuilder.DropTable(
                name: "SessionsUser");

            migrationBuilder.DeleteData(
                table: "ActivityRoom",
                keyColumns: new[] { "ActivityId", "RoomId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ActivityRoom",
                keyColumns: new[] { "ActivityId", "RoomId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ActivityRoom",
                keyColumns: new[] { "ActivityId", "RoomId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ActivityRoom",
                keyColumns: new[] { "ActivityId", "RoomId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ActivityRoom",
                keyColumns: new[] { "ActivityId", "RoomId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ActivityRoom",
                keyColumns: new[] { "ActivityId", "RoomId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "ActivityRoom",
                newName: "RoomsId");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "ActivityRoom",
                newName: "ActivitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityRoom_RoomId",
                table: "ActivityRoom",
                newName: "IX_ActivityRoom_RoomsId");

            migrationBuilder.CreateTable(
                name: "SessionUser",
                columns: table => new
                {
                    SessionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUser", x => new { x.SessionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SessionUser_Sessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionUser_UsersId",
                table: "SessionUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityRoom_Activities_ActivitiesId",
                table: "ActivityRoom",
                column: "ActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityRoom_Rooms_RoomsId",
                table: "ActivityRoom",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
