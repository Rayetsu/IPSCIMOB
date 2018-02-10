using IPSCIMOB.Controllers;
using IPSCIMOB.Data;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class CandidaturaControllerTest
    {
        public ApplicationDbContext dbContext;
        [TestMethod]
        public void AdicionarCandidaturaTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseInMemoryDatabase();
           
            var userManager = new Mock<UserManager<ApplicationUser>>();
            //var candidaturaController = new CandidaturaController(dbContext, userManager);
        }
    }
}
