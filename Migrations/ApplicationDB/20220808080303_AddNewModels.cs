using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard_DW_V2.Migrations.ApplicationDB
{
    public partial class AddNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailChartBar",
                columns: table => new
                {
                    Month = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountSent = table.Column<int>(type: "int", nullable: false),
                    CountSentSuccesful = table.Column<int>(type: "int", nullable: false),
                    CountEmailsOpened = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailChartBar", x => x.Month);
                });

            migrationBuilder.CreateTable(
                name: "PreferencestoChartPie",
                columns: table => new
                {
                    Count = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountEmailOptin = table.Column<int>(type: "int", nullable: false),
                    CountMailOptin = table.Column<int>(type: "int", nullable: false),
                    CountPhoneOptin = table.Column<int>(type: "int", nullable: false),
                    CountSmsOptin = table.Column<int>(type: "int", nullable: false),
                    CountNoOptin = table.Column<int>(type: "int", nullable: false),
                    CountMoreThanOneOptin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferencestoChartPie", x => x.Count);
                });

            migrationBuilder.CreateTable(
                name: "visitChart",
                columns: table => new
                {
                    MonthYear = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Visitors = table.Column<int>(type: "int", nullable: false),
                    DirectSpent = table.Column<float>(type: "real", nullable: false),
                    IndirectSpent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitChart", x => x.MonthYear);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailChartBar");

            migrationBuilder.DropTable(
                name: "PreferencestoChartPie");

            migrationBuilder.DropTable(
                name: "visitChart");
        }
    }
}
