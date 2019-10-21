using Microsoft.EntityFrameworkCore.Migrations;

namespace LastSpikeApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Latitude", "Longitude", "Name" },
                values: new object[] { 1, 53.4854713, -2.2507676000000001, "example1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Latitude", "Longitude", "Name" },
                values: new object[] { 2, 53.475851200000001, -2.2485708999999998, "example2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Latitude", "Longitude", "Name" },
                values: new object[] { 3, 53.488216299999998, -2.2352457000000001, "example3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);
        }
    }
}
