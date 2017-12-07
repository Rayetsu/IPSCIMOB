using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPSCIMOB.Data.Migrations
{
    public partial class UtilizadorRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilizador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    UtilizadorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ano = table.Column<string>(nullable: true),
                    Curso = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsAdministrador = table.Column<bool>(nullable: false),
                    IsDadosConfirmados = table.Column<bool>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: false),
                    NumeroDoBI = table.Column<int>(nullable: false),
                    NumeroInterno = table.Column<int>(nullable: false),
                    PalavraPasse = table.Column<string>(maxLength: 20, nullable: false),
                    PartilhaMobilidade = table.Column<bool>(nullable: false),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.UtilizadorID);
                });
        }
    }
}
