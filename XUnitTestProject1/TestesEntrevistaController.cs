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
    public class TestesEntrevistaController : Controller
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        //[Fact]
        //public async Task TestCreateEntrevista()
        //{
        //    optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    optionsBuilder.UseInMemoryDatabase();
        //    _dbContext = new ApplicationDbContext(optionsBuilder.Options);

        //    // Arrange
        //    var controller = new EntrevistasController(_dbContext);

        //    // Act
        //    var entrevista = new Entrevista()
        //    {
        //        NumeroAluno = 140221050,
        //        Email = "someone1995@hotmail.com",
        //        EntrevistaAtual = false,
        //        DataDeEntrevista = new DateTime(2017, 07, 23, 10, 30, 0),
        //        Estado = EstadoEntrevista.EmEspera,
        //        NomePrograma = "Erasmus+ FUNCIONÁRIOS"
        //    };
        //    var result = await controller.Create(entrevista);

        //    var res = await _dbContext.Entrevista.SingleOrDefaultAsync(m => m.EntrevistaId == entrevista.EntrevistaId);
        //    Assert.Equal(entrevista, res);
        //    Assert.Equal(140221050, entrevista.NumeroAluno);
        //}
    }
}
