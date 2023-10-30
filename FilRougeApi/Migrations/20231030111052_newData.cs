using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilRougeApi.Migrations
{
    /// <inheritdoc />
    public partial class newData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fitness" },
                    { 2, "Yoga" },
                    { 3, "Danse" },
                    { 4, "Zumba" },
                    { 5, "Pilates" },
                    { 6, "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImageURL", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "/images/yoga.PNG", "1er étage - 4 rue tartempion Lille", "Salle1" },
                    { 2, "/images/fitness.PNG", "RDC - 4 rue tartempion Lille", "Salle2" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CloseTime", "Day", "OpenTime", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(1900, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "Monday", new DateTime(1900, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(1900, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", new DateTime(1900, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(1900, 1, 1, 20, 0, 0, 0, DateTimeKind.Local), "Monday", new DateTime(1900, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(1900, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", new DateTime(1900, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "EndTime", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 11, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 11, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "Rating", "SessionId", "UserId" },
                values: new object[,]
                {
                    { 1, "Message Comment 1 ...", 2, 1, 2 },
                    { 2, "Message Comment 2 ...", 3, 1, 2 },
                    { 3, "Message Comment 3 ...", 4, 2, 2 },
                    { 4, "Message Comment 4 ...", 5, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomId",
                table: "Sessions",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Rooms_RoomId",
                table: "Sessions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Rooms_RoomId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_RoomId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
