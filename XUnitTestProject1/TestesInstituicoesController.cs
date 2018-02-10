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
        public async Task TestCreateInsitituicaoParceira()
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

            var res = await _dbContext.InstituicaoParceiraModel.SingleOrDefaultAsync(m => m.InstituicaoParceiraID == i.InstituicaoParceiraID);
            Assert.Equal(i, res);
            Assert.Equal("Instituto Politecnico de Sines", i.Nome);
        }

        //public async Task TestDeleteInsitituicaoParceira()
        //{
        //    optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    optionsBuilder.UseInMemoryDatabase();
        //    _dbContext = new ApplicationDbContext(optionsBuilder.Options);

        //    Arrange
        //   var controller = new InstituicaoParceiraController(_dbContext);

        //    Act
        //   var i = new InstituicaoParceiraModel()
        //   {
        //       Nome = "Instituto Politecnico de Braga",
        //       Cidade = "Braga",
        //       ProgramaNome = "Erasmus+ FUNCIONARIOS"
        //   };
        //    var result = await controller.Delete(i.InstituicaoParceiraID);

        //    var res = await _dbContext.InstituicaoParceiraModel.SingleOrDefaultAsync(m => m.InstituicaoParceiraID == i.InstituicaoParceiraID);
        //    Assert.Contains();
        //    Assert.Equal("Instituto Politecnico de Sines", i.Nome);
        //}
    }
}
