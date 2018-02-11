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
using System.Security.Claims;

namespace XUnitTestProject1
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TestesCandidaturaController : Controller
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        //private CandidaturaController candidaturas;
        private UserManager<ApplicationUser> userManager;
        //private RoleManager<IdentityRole> _roleManager;

        public TestesCandidaturaController()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=aspnet-IPSCIMOB-62721098-BD60-4CA2-8125-8EB3F02474C3;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            //var passwordManager = userStore.As<IUserPasswordStore<ApplicationUser>>();
            userManager = new UserManager<ApplicationUser>(userStore.Object, null, null, null, null, null, null, null, null);
        }


        [Fact]
        public async Task TestIndex()
        {
            // Arrange
            var sut = new CandidaturaController(_dbContext, userManager);
            

            // Act
            var result = sut.Index() as Task<IActionResult>;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IActionResult>(await result);
        }

        [Fact]
        public void ConsultarCandidaturaAluno()
        {
            // Arrange
            var sut = new CandidaturaController(_dbContext, userManager);


            // Act
            var result = sut.ConsultarCandidaturaAluno();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        //[Fact]
        //public async Task CandidaturaCreateTest()
        //{
        //    ApplicationUser user = new ApplicationUser
        //    {
        //        UserName = "aluno@email.com",
        //        Email = "aluno@email.com",
        //        Nome = "ALUNO",
        //        NumeroInterno = 142327134,
        //        NumeroDoBI = 915542421,
        //        Morada = "rua",
        //        NumeroDaPorta = 3,
        //        Andar = "2ºDto.",
        //        CodigoPostal = "2844-014",
        //        Cidade = "Seixal",
        //        Distrito = "Setúbal",
        //        Nacionalidade = "Portugal",
        //        Telefone = 123453489,
        //        DataDeNascimento = new DateTime(2000, 12, 9),
        //        EmailConfirmed = true,
        //        IsDadosVerificados = true,
        //        PartilhaMobilidade = true,
        //        IsFuncionario = false
        //    };


        //    //IdentityResult result2 = userManager.CreateAsync(user, "Ips123!").Result;
        //    _dbContext.Add(user);

        //    //var cp = new Mock<ClaimsPrincipal>();

        //    var signIn = new Mock<SignInManager<ApplicationUser>>();

        //    await userManager.GetUserAsync(User);

        //    //ApplicationUser a = new ApplicationUser();
        //    //_dbContext.Users.Add(a);

        //    //var userStore = new Mock<IUserStore<ApplicationUser>>();
        //    //var userManager = new UserManager<ApplicationUser>(userStore.Object, null, null, null, null, null, null, null, null);

        //    var controller = new CandidaturaController(_dbContext, userManager);

        //    var c = new CandidaturaModel()
        //    {
        //        Programa = "Santander Universidades - BOLSAS IBERO-AMERICANAS"
        //    };

        //    var result = await controller.Create(c);

        //    var candidatura = await _dbContext.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == c.CandidaturaID);
        //    Assert.Equal(c, candidatura);
        //    Assert.Equal("Santander Universidades - BOLSAS IBERO-AMERICANAS", candidatura.Programa);

        //    //var result2 = await controller.Edit(candidatura.CandidaturaID) as ViewResult;
        //    //Assert.Equal(result2.Model, c);
        //}








    }
}
