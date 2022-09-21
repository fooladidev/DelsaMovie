using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelsaMovie.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ca1c44e-5dd5-4104-86ee-ce43fb512e3a", "217517bd-e5d7-49d1-ada5-10fd60988b4e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc4b9350-94ad-47f5-8f78-6753d6bf3ad8", "5d350acb-d616-491a-8552-788afad62846", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca1c44e-5dd5-4104-86ee-ce43fb512e3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc4b9350-94ad-47f5-8f78-6753d6bf3ad8");
        }
    }
}
