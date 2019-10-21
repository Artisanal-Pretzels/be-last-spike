using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LastSpikeApi.Migrations
{
  public partial class InitialUser : Migration
  {
    protected override void Up (MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable (
        name: "User",
        columns : table => new
        {
          ID = table.Column<int> (nullable: false)
            .Annotation ("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Latitude = table.Column<double> (nullable: false),
            Longitude = table.Column<double> (nullable: false),
            Name = table.Column<string> (nullable: true)
        },
        constraints : table =>
        {
          table.PrimaryKey ("PK_User", x => x.ID);
        });
    }

    protected override void Down (MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable (
        name: "User");
    }
  }
}