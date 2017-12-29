using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPSCIMOB.Migrations
{
    public partial class ForeignStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForeignStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Andar = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<string>(maxLength: 50, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Distrito = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EscolaIPSECurso = table.Column<string>(maxLength: 100, nullable: false),
                    IsBolseiro = table.Column<bool>(nullable: false),
                    IsDadosVerificados = table.Column<bool>(nullable: false),
                    IsFuncionario = table.Column<bool>(nullable: false),
                    Morada = table.Column<string>(maxLength: 50, nullable: false),
                    Nacionalidade = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    NumeroDaPorta = table.Column<int>(nullable: false),
                    PartilhaMobilidade = table.Column<bool>(nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    Universidade = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignStudent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForeignStudent");
        }
    }
}
