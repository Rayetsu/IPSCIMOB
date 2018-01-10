﻿// <auto-generated />
using IPSCIMOB.Data;
using IPSCIMOB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IPSCIMOB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IPSCIMOB.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Andar")
                        .HasMaxLength(50);

                    b.Property<int>("CandidaturaAtual");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Distrito")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsDadosVerificados");

                    b.Property<bool>("IsFuncionario");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int>("NumeroDaPorta");

                    b.Property<int>("NumeroDoBI");

                    b.Property<int>("NumeroInterno");

                    b.Property<bool>("PartilhaMobilidade");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Telefone");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IPSCIMOB.Models.CandidaturaModel", b =>
                {
                    b.Property<int>("CandidaturaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("EntrevistaID");

                    b.Property<int>("Estado");

                    b.Property<int>("EstadoBolsa");

                    b.Property<int>("EstadoDocumentos");

                    b.Property<bool>("IsBolsa");

                    b.Property<bool>("IsConfirmado");

                    b.Property<bool>("IsEstagio");

                    b.Property<bool>("IsEstudo");

                    b.Property<bool>("IsFormacao");

                    b.Property<bool>("IsInvestigacao");

                    b.Property<bool>("IsLecionar");

                    b.Property<string>("Nome");

                    b.Property<int>("NumeroInterno");

                    b.Property<int>("Pais");

                    b.Property<string>("Programa");

                    b.HasKey("CandidaturaID");

                    b.ToTable("CandidaturaModel");
                });

            modelBuilder.Entity("IPSCIMOB.Models.Entrevista", b =>
                {
                    b.Property<int>("EntrevistaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeEntrevista");

                    b.Property<string>("Email");

                    b.Property<int>("Estado");

                    b.Property<int?>("NumeroAluno");

                    b.HasKey("EntrevistaId");

                    b.ToTable("Entrevista");
                });

            modelBuilder.Entity("IPSCIMOB.Models.EnviarMsg", b =>
                {
                    b.Property<int>("EnviarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EMailBody");

                    b.Property<string>("EmailSubject");

                    b.Property<string>("ToEmail")
                        .IsRequired();

                    b.HasKey("EnviarId");

                    b.ToTable("EnviarMsg_1");
                });

            modelBuilder.Entity("IPSCIMOB.Models.ForeignStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Andar")
                        .HasMaxLength(50);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Distrito")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EscolaIPSECurso")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsBolseiro");

                    b.Property<bool>("IsDadosVerificados");

                    b.Property<bool>("IsFuncionario");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("NumeroDaPorta");

                    b.Property<bool>("PartilhaMobilidade");

                    b.Property<int>("Telefone");

                    b.Property<string>("Universidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ForeignStudents");
                });

            modelBuilder.Entity("IPSCIMOB.Models.InformacaoGeral", b =>
                {
                    b.Property<int>("InformacaoGeralID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<bool>("ProgramaAtual");

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.HasKey("InformacaoGeralID");

                    b.ToTable("InformacaoGeral");
                });

            modelBuilder.Entity("IPSCIMOB.Models.Sugestao", b =>
                {
                    b.Property<int>("SugestaoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailUtilizador");

                    b.Property<string>("TextoSugestao");

                    b.HasKey("SugestaoID");

                    b.ToTable("Sugestao");
                });

            modelBuilder.Entity("IPSCIMOB.Models.Upload.AlunoDocumentos", b =>
                {
                    b.Property<int>("InsertId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caminho")
                        .IsRequired();

                    b.Property<string>("Documento")
                        .IsRequired();

                    b.Property<int?>("NumeroAluno");

                    b.HasKey("InsertId");

                    b.ToTable("AlunoDocumento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IPSCIMOB.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IPSCIMOB.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPSCIMOB.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("IPSCIMOB.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
