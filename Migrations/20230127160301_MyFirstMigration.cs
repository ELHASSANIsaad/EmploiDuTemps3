using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploiDuTemps.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasseMatierProfs",
                columns: table => new
                {
                    nameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prof = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseMatierProfs", x => x.nameId);
                });

            migrationBuilder.CreateTable(
                name: "EmploiClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_EmploiClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploiProfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_EmploiProfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploiSalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_EmploiSalles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filliers",
                columns: table => new
                {
                    NameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filliers", x => x.NameId);
                });

            migrationBuilder.CreateTable(
                name: "Profs",
                columns: table => new
                {
                    cinId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    informtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hasEmploi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profs", x => x.cinId);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    nameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    capacite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hasEmploi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.nameId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    NameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nbrEtudiant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hasEmploi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillierId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.NameId);
                    table.ForeignKey(
                        name: "FK_Classes_Filliers_FillierId",
                        column: x => x.FillierId,
                        principalTable: "Filliers",
                        principalColumn: "NameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matiers",
                columns: table => new
                {
                    nameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    volumHoraireH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    volumHoraireHs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillierId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiers", x => x.nameId);
                    table.ForeignKey(
                        name: "FK_Matiers_Filliers_FillierId",
                        column: x => x.FillierId,
                        principalTable: "Filliers",
                        principalColumn: "NameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    cneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    informtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClasseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.cneId);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "NameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FillierId",
                table: "Classes",
                column: "FillierId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_ClasseId",
                table: "Etudiants",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiers_FillierId",
                table: "Matiers",
                column: "FillierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasseMatierProfs");

            migrationBuilder.DropTable(
                name: "EmploiClasses");

            migrationBuilder.DropTable(
                name: "EmploiProfs");

            migrationBuilder.DropTable(
                name: "EmploiSalles");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Matiers");

            migrationBuilder.DropTable(
                name: "Profs");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Filliers");
        }
    }
}
