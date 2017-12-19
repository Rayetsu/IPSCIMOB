using IPSCIMOB.Controllers;
using IPSCIMOB.Data;
using IPSCIMOB.Models;
using IPSCIMOB.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        //private ApplicationDbContext Context { get; }
        //private UserManager<ApplicationUser> UserManager { get; }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private ApplicationDbContext _dbContext;

        [Fact]
        public void Test1()
        {
            HomeController home = new HomeController();

            IActionResult result = home.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
