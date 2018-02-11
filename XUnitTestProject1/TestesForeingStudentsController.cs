﻿using System;
using System.Collections.Generic;
using System.Text;
using IPSCIMOB.Data;
using IPSCIMOB.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using IPSCIMOB.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace XUnitTestProject1
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TestesForeingStudentsController : Controller
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        [Fact]
        public async Task TestCreateForeignStudent()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new ForeignStudentsController(_dbContext);

            // Act
            var student = new ForeignStudents()
            {
                Nome = "Joana Silva",
                Nacionalidade = "USA",
                Email = "jusilva@gmail.com",
                DataDeNascimento = new DateTime(1997, 12, 29),
                EscolaIPSECurso = "EST, EI",
                Morada = "Main Street Avenue",
                NumeroDaPorta = 34,
                Andar = "2",
                Cidade = "New York",
                Distrito = "distric1",
                CodigoPostal = "45755-7856",
                Universidade = "NY University",
                IsBolseiro = false,
                IsFuncionario = false,
                IsDadosVerificados = true
            };

            var result = await controller.Create(student);

            var res = await _dbContext.ForeignStudents.SingleOrDefaultAsync(m => m.Id == student.Id);
            Assert.Equal(student, res);
            Assert.Equal("Joana Silva", student.Nome);
        }

        [Fact]
        public async Task TestDeleteForeingStudents()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new ForeignStudentsController(_dbContext);

            // Act
            var student = new ForeignStudents()
            {
                Nome = "Joana Silva",
                Nacionalidade = "USA",
                Email = "jusilva@gmail.com",
                DataDeNascimento = new DateTime(1997, 12, 29),
                EscolaIPSECurso = "EST, EI",
                Morada = "Main Street Avenue",
                NumeroDaPorta = 34,
                Andar = "2",
                Cidade = "New York",
                Distrito = "distric1",
                CodigoPostal = "45755-7856",
                Universidade = "NY University",
                IsBolseiro = false,
                IsFuncionario = false,
                IsDadosVerificados = true
            };
            await controller.Create(student);

            await controller.DeleteConfirmed(student.Id);

            var res = await _dbContext.ForeignStudents.SingleOrDefaultAsync(m => m.Id == student.Id);
            Assert.Null(res);
        }

        [Fact]
        public async Task TestEditarForeingStudent()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new ForeignStudentsController(_dbContext);

            // Act
            var student = new ForeignStudents()
            {
                Nome = "Ruan Bandera",
                Nacionalidade = "Americano",
                Email = "ruanzinho@gmail.com",
                DataDeNascimento = new DateTime(1997, 12, 29),
                EscolaIPSECurso = "EST, EI",
                Morada = "Main Street Avenue",
                NumeroDaPorta = 34,
                Andar = "2",
                Cidade = "New York",
                Distrito = "distric1",
                CodigoPostal = "45755-7856",
                Universidade = "NY University",
                IsBolseiro = false,
                IsFuncionario = false,
                IsDadosVerificados = true
            };
            await controller.Create(student);

            student.Nome = "Ruan De La Bandera";
            student.Email = "mexicanBoy@email.com";
            student.IsBolseiro = true;
            student.Nacionalidade = "Mexicano";
            await controller.Edit(student.Id, student);

            var res = await _dbContext.ForeignStudents.SingleOrDefaultAsync(m => m.Id == student.Id);
            Assert.Equal(res.Nome, student.Nome);
            Assert.Equal("Ruan De La Bandera", res.Nome);
            Assert.Equal("mexicanBoy@email.com", res.Email);
            Assert.True(res.IsBolseiro);
            Assert.Equal("Mexicano", res.Nacionalidade);
        }


    }
}
