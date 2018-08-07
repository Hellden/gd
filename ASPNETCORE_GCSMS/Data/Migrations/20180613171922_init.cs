using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORE_GCSMS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GCSMS_Etablissement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ehpad = table.Column<int>(nullable: true),
                    Fah = table.Column<int>(nullable: true),
                    Fam = table.Column<int>(nullable: true),
                    Foyer = table.Column<int>(nullable: true),
                    IframeGoogle = table.Column<string>(nullable: true),
                    Jour = table.Column<int>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Pasa = table.Column<int>(nullable: true),
                    Temporaire = table.Column<int>(nullable: true),
                    Uhr = table.Column<int>(nullable: true),
                    Usa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCSMS_Etablissement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCSMS_Formation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categorie = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCSMS_Formation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCSMS_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EtablissementId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCSMS_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCSMS_Users_GCSMS_Etablissement_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "GCSMS_Etablissement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GCSMS_Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCSMS_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GCSMS_Posts_GCSMS_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "GCSMS_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GCSMS_Posts_UserId",
                table: "GCSMS_Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GCSMS_Users_EtablissementId",
                table: "GCSMS_Users",
                column: "EtablissementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GCSMS_Formation");

            migrationBuilder.DropTable(
                name: "GCSMS_Posts");

            migrationBuilder.DropTable(
                name: "GCSMS_Users");

            migrationBuilder.DropTable(
                name: "GCSMS_Etablissement");
        }
    }
}
