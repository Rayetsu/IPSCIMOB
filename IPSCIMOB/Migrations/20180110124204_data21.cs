using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPSCIMOB.Migrations
{
    public partial class data21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoDocumento",
                columns: table => new
                {
                    InsertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caminho = table.Column<string>(nullable: false),
                    Documento = table.Column<string>(nullable: false),
                    NumeroAluno = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDocumento", x => x.InsertId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Andar = table.Column<string>(maxLength: 50, nullable: true),
                    CandidaturaAtual = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<string>(maxLength: 50, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Distrito = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    IsDadosVerificados = table.Column<bool>(nullable: false),
                    IsFuncionario = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Morada = table.Column<string>(maxLength: 50, nullable: false),
                    Nacionalidade = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NumeroDaPorta = table.Column<int>(nullable: false),
                    NumeroDoBI = table.Column<int>(nullable: false),
                    NumeroInterno = table.Column<int>(nullable: false),
                    PartilhaMobilidade = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidaturaModel",
                columns: table => new
                {
                    CandidaturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    EntrevistaID = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    EstadoBolsa = table.Column<int>(nullable: false),
                    EstadoDocumentos = table.Column<int>(nullable: false),
                    IsBolsa = table.Column<bool>(nullable: false),
                    IsConfirmado = table.Column<bool>(nullable: false),
                    IsEstagio = table.Column<bool>(nullable: false),
                    IsEstudo = table.Column<bool>(nullable: false),
                    IsFormacao = table.Column<bool>(nullable: false),
                    IsInvestigacao = table.Column<bool>(nullable: false),
                    IsLecionar = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    NumeroInterno = table.Column<int>(nullable: false),
                    Pais = table.Column<int>(nullable: false),
                    Programa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidaturaModel", x => x.CandidaturaID);
                });

            migrationBuilder.CreateTable(
                name: "Entrevista",
                columns: table => new
                {
                    EntrevistaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDeEntrevista = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    NumeroAluno = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrevista", x => x.EntrevistaId);
                });

            migrationBuilder.CreateTable(
                name: "EnviarMsg_1",
                columns: table => new
                {
                    EnviarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMailBody = table.Column<string>(nullable: true),
                    EmailSubject = table.Column<string>(nullable: true),
                    ToEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviarMsg_1", x => x.EnviarId);
                });

            migrationBuilder.CreateTable(
                name: "ForeignStudents",
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
                    table.PrimaryKey("PK_ForeignStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacaoGeral",
                columns: table => new
                {
                    InformacaoGeralID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    ProgramaAtual = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoGeral", x => x.InformacaoGeralID);
                });

            migrationBuilder.CreateTable(
                name: "Sugestao",
                columns: table => new
                {
                    SugestaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailUtilizador = table.Column<string>(nullable: true),
                    TextoSugestao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugestao", x => x.SugestaoID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDocumento");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CandidaturaModel");

            migrationBuilder.DropTable(
                name: "Entrevista");

            migrationBuilder.DropTable(
                name: "EnviarMsg_1");

            migrationBuilder.DropTable(
                name: "ForeignStudents");

            migrationBuilder.DropTable(
                name: "InformacaoGeral");

            migrationBuilder.DropTable(
                name: "Sugestao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
