using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Interview.Infrastructure.Migrations
{
    public partial class InitialMigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressID", "CreatedById", "CreatedOn", "Name", "UpdatedByID", "UpdatedOn" },
                values: new object[] { new Guid("15789274-a08e-4ccb-a149-bde633421026"), null, null, new DateTime(2021, 9, 22, 23, 34, 22, 113, DateTimeKind.Local).AddTicks(3151), "ABC Client", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("15789274-a08e-4ccb-a149-bde633421026"));
        }
    }
}
