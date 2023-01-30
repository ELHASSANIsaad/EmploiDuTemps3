using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploiDuTemps.Migrations
{
    /// <inheritdoc />
    public partial class addintPEmpTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfEmplois",
                columns: table => new
                {
                    profEmploiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    prof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfEmplois", x => x.profEmploiId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfEmplois");
        }
    }
}
