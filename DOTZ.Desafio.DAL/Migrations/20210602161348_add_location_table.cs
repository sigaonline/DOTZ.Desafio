using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOTZ.Desafio.DAL.Migrations
{
    public partial class add_location_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(9)", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", nullable: false),
                    Number = table.Column<string>(type: "varchar(5)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(100)", nullable: false),
                    District = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
