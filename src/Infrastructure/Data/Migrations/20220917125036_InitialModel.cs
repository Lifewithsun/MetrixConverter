using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "MatrixData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ConvertFrom = table.Column<string>(type: "varchar(500)", nullable: false),
                    ConvertTo = table.Column<string>(type: "varchar(500)", nullable: false),
                    MutliplyBy = table.Column<string>(type: "varchar(500)", nullable: false),
                    IsDecimal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatrixData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatrixData");
        }
    }
}
