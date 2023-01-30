﻿// <auto-generated />
using EmploiDuTemps.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmploiDuTemps.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230128155620_updateKeyAutoGen")]
    partial class updateKeyAutoGen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmploiDuTemps.Models.Classe", b =>
                {
                    b.Property<string>("NameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FillierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hasEmploi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nbrEtudiant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NameId");

                    b.HasIndex("FillierId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.ClasseMatierProf", b =>
                {
                    b.Property<string>("nameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prof")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nameId");

                    b.ToTable("ClasseMatierProfs");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.EmploiClasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prof")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmploiClasses");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.EmploiProf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prof")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmploiProfs");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.EmploiSalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prof")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmploiSalles");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Etudiant", b =>
                {
                    b.Property<string>("cneId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClasseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("informtion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cneId");

                    b.HasIndex("ClasseId");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Fillier", b =>
                {
                    b.Property<string>("NameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NameId");

                    b.ToTable("Filliers");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Matier", b =>
                {
                    b.Property<string>("nameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FillierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("volumHoraireH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("volumHoraireHs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nameId");

                    b.HasIndex("FillierId");

                    b.ToTable("Matiers");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Prof", b =>
                {
                    b.Property<string>("cinId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("hasEmploi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("informtion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cinId");

                    b.ToTable("Profs");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Salle", b =>
                {
                    b.Property<string>("nameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("capacite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hasEmploi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nameId");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Classe", b =>
                {
                    b.HasOne("EmploiDuTemps.Models.Fillier", "Fillier")
                        .WithMany()
                        .HasForeignKey("FillierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fillier");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Etudiant", b =>
                {
                    b.HasOne("EmploiDuTemps.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("EmploiDuTemps.Models.Matier", b =>
                {
                    b.HasOne("EmploiDuTemps.Models.Fillier", "Fillier")
                        .WithMany()
                        .HasForeignKey("FillierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fillier");
                });
#pragma warning restore 612, 618
        }
    }
}
