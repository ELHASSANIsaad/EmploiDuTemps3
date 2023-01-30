using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploiDuTemps.Migrations
{
    /// <inheritdoc />
    public partial class createTablForEmploiClassAndSall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasseEmplois",
                columns: table => new
                {
                    classeEmploiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseEmplois", x => x.classeEmploiId);
                });

            migrationBuilder.CreateTable(
                name: "SalleEmplois",
                columns: table => new
                {
                    salleEmploiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    salle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalleEmplois", x => x.salleEmploiId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasseEmplois");

            migrationBuilder.DropTable(
                name: "SalleEmplois");
        }
    }
}
