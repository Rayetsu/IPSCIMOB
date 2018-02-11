using System;
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
    public class TestesInstituicoesController : Controller
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        [Fact]
        public async Task TestCreateInstituicaoParceira()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new InstituicaoParceiraController(_dbContext);

            // Act
            var i = new InstituicaoParceiraModel()
            {
                Nome = "Instituto Politecnico de Sines",
                Cidade = "Sines",
                ProgramaNome = "Erasmus+ ALUNOS"
            };
            var result = await controller.Create(i);

            var res = await _dbContext.InstituicaoParceiraModel.SingleOrDefaultAsync
                (m => m.InstituicaoParceiraID == i.InstituicaoParceiraID);
            Assert.Equal(i, res);
            Assert.Equal("Instituto Politecnico de Sines", i.Nome);
        }

        [Fact]
        public async Task TestDeleteInsitituicaoParceira()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new InstituicaoParceiraController(_dbContext);

            // Act
            var i = new InstituicaoParceiraModel()
            {
                Nome = "Instituto Politecnico para Eliminar",
                Pais = "DeleteCountry",
                Cidade = "DeleteCity",
                ProgramaNome = "Erasmus+ FUNCIONARIOS"
            };
            await controller.Create(i);
            await controller.DeleteConfirmed(i.InstituicaoParceiraID);

            var res = await _dbContext.InstituicaoParceiraModel.SingleOrDefaultAsync(m => m.InstituicaoParceiraID == i.InstituicaoParceiraID);
            Assert.Null(res);
        }


        [Fact]
        public async Task TestEditarInsitituicaoParceira()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new InstituicaoParceiraController(_dbContext);

            // Act
            var i = new InstituicaoParceiraModel()
            {
                Nome = "Instituto Politecnico para Editar",
                Pais = "França",
                Cidade = "Nantes",
                ProgramaNome = "Erasmus+ FUNCIONARIOS"
            };
            await controller.Create(i);

            i.Nome = "Instituto Politecnico Editado";
            i.Pais = "Alemanha";
            i.Cidade = "Frankfurt";
            i.ProgramaNome = "Erasmus+ ALUNOS";
            await controller.Edit(i.InstituicaoParceiraID, i);

            var res = await _dbContext.InstituicaoParceiraModel.SingleOrDefaultAsync(m => m.InstituicaoParceiraID == i.InstituicaoParceiraID);
            Assert.Equal(res.Nome, i.Nome);
            Assert.Equal("Instituto Politecnico Editado", res.Nome);
            Assert.Equal("Alemanha", res.Pais);
            Assert.Equal("Frankfurt", res.Cidade);
            Assert.Equal("Erasmus+ ALUNOS", res.ProgramaNome);
        }


    }

}
