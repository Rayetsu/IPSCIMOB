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
    public class TestesEnviarMsgController
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        [Fact]
        public async Task TestCreateEnviarMensagem()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Arrange
            var controller = new EnviarMsgsController(_dbContext);

            // Act
            var msg = new EnviarMsg()
            {
                ToEmail = "someone1995@hotmail.com",
                EMailBody = "CIMOB - Documentos Em Falta",
                EmailSubject = "Bom dia. Vimos por este meio informar que a sua candidatura ao " +
                "Programa Erasmus+ tem os seguintes documentos em falta: " +
                "1. Certificado de Residência; 2. Comprovativo de Morada. " +
                "Por favor entre na sua conta e submeta os documentos em falta. Obrigado, CIMOB"
            };

            var result = await controller.Create(msg);

            var res = await _dbContext.EnviarMsg_1.SingleOrDefaultAsync(m => m.EnviarId == msg.EnviarId);
            Assert.Equal(msg, res);
            Assert.Equal("CIMOB - Documentos Em Falta", msg.EMailBody);
        }
    }
}
