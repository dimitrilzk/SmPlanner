using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmPlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Societa = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Citta = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    DataInizioRapporto = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DataFineRapporto = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    ImportoMensile = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NoteEAccordi = table.Column<string>(type: "TEXT", nullable: true),
                    ColoreHex = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    SponsorizzateAlMese = table.Column<int>(type: "INTEGER", nullable: false),
                    NewsletterAlMese = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientePianificazioneGiorni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Giorno = table.Column<int>(type: "INTEGER", nullable: false),
                    Post = table.Column<bool>(type: "INTEGER", nullable: false),
                    Storie = table.Column<bool>(type: "INTEGER", nullable: false),
                    Reel = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePianificazioneGiorni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientePianificazioneGiorni_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientePianificazioneGiorni_ClienteId",
                table: "ClientePianificazioneGiorni",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientePianificazioneGiorni");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
