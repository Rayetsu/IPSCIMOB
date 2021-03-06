﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IPSCIMOB.Models;

namespace IPSCIMOB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            
            
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ForeignStudents> ForeignStudent { get; set; }

        public DbSet<IPSCIMOB.Models.Sugestao> Sugestao { get; set; }

        public DbSet<IPSCIMOB.Models.InformacaoGeral> InformacaoGeral { get; set; }

        public DbSet<CandidaturaModel> CandidaturaModel { get; set; }

        public DbSet<IPSCIMOB.Models.Entrevista> Entrevista { get; set; }

        public DbSet<IPSCIMOB.Models.Upload.AlunoDocumentos> AlunoDocumento{ get; set; }


        public DbSet<IPSCIMOB.Models.ForeignStudents> ForeignStudents { get; set; }

        public DbSet<IPSCIMOB.Models.EnviarMsg> EnviarMsg_1 { get; set; }

        public DbSet<IPSCIMOB.Models.ProgramaModel> ProgramaModel { get; set; }

        public DbSet<IPSCIMOB.Models.InstituicaoParceiraModel> InstituicaoParceiraModel { get; set; }


    }
}
