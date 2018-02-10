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
    public class TestesCandidaturaController: Controller
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        private CandidaturaController candidaturas;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> _roleManager;


        [Fact]
        public async Task CandidaturaCreateEditTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            ApplicationUser a = new ApplicationUser();
            _dbContext.Users.Add(a);

            var controller = new CandidaturaController(_dbContext, userManager);


            
        }
    }
}
