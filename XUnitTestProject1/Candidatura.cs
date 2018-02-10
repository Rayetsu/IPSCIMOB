using IPSCIMOB.Controllers;
using IPSCIMOB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    class Candidatura
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;

        [Fact]
        public async Task CandidaturasControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        }

    }
}
