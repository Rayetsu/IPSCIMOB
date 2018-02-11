using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium3_7_VisualStudio2017
{
    [TestClass]
    public class GoogleSearchEngineUsingFireFox
    {
        [TestMethod]
        public void TesteCriarCandidatura123Fase()
        {
            // Initialize the Firefox Driver
            using (IWebDriver driver = new FirefoxDriver(@"D:\stremio-cache"))
            {
                // 1. Maximize the browser
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://cimobips-001-site1.atempurl.com");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                IWebElement query = driver.FindElement(By.Id("Login"));
                query.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                query = driver.FindElement(By.Id("Email"));
                query.SendKeys("projcimob@gmail.com");
                query = driver.FindElement(By.Id("Password"));
                query.SendKeys("Ips123!");
                query = driver.FindElement(By.Id("Login1"));
                query.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

                query = driver.FindElement(By.XPath("//a[contains(text(),'Erasmus+ ALUNOS')]"));
                query.Click();
                driver.Navigate().Back();
                query = driver.FindElement(By.XPath("//a[contains(text(),'Politécnico de Macau')]"));
                query.Click();
                driver.Navigate().Back();
                query = driver.FindElement(By.XPath("//a[contains(text(),'Santander Universidades - BOLSAS IBERO-AMERICANAS')]"));
                query.Click();
                driver.Navigate().Back();
                query = driver.FindElement(By.XPath("//a[contains(text(),'Santander Universidades - BOLSAS LUSO-BRASILEIRAS')]"));
                query.Click();
                driver.Navigate().Back();
                query = driver.FindElement(By.XPath("//a[contains(text(),'Vasco Da Gama')]"));
                query.Click();

                query = driver.FindElement(By.XPath("//a[contains(text(),'Consultar Candidatura')]"));
                query.Click();
                query = driver.FindElement(By.Id("IsBolsa"));
                query.Click();
                query = driver.FindElement(By.Id("IsEstagio"));
                query.Click();
                query.Click();
                query = driver.FindElement(By.Id("IsEstudo"));
                query.Click();
                SelectElement select = new SelectElement(driver.FindElement(By.Id("Semestre")));
                select.SelectByText("1ºSemestre");
                select.SelectByText("2ºSemestre");
                select = new SelectElement(driver.FindElement(By.Id("InstituicaoNome")));
                select.SelectByText("Instituto Politécnico de Coimbra");
                query = driver.FindElement(By.Id("submeterCandidatura"));
                query.Click();

                query = driver.FindElement(By.Id("IsConfirmado"));
                query.Click();
                query = driver.FindElement(By.Id("confirmar"));
                query.Click();

                query = driver.FindElement(By.Id("subDocs"));
                query.Click();

                driver.Quit();
            }
        }

        [TestMethod]
        public void TesteAprovarDocumentos()
        {
            // Initialize the Firefox Driver
            using (IWebDriver driver = new FirefoxDriver(@"D:\stremio-cache"))
            {
                // 1. Maximize the browser
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://cimobips-001-site1.atempurl.com");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                IWebElement query = driver.FindElement(By.Id("Login"));
                query.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                query = driver.FindElement(By.Id("Email"));
                query.SendKeys("cimob@email.com");
                query = driver.FindElement(By.Id("Password"));
                query.SendKeys("Ips123!");
                query = driver.FindElement(By.Id("Login1"));
                query.Click();

                query = driver.FindElement(By.XPath("//input[@value='Gestão de Candidaturas']"));
                query.Click();

                query = driver.FindElement(By.XPath("(//a[contains(text(),'Editar')])[7]"));
                query.Click();

                SelectElement select = new SelectElement(driver.FindElement(By.Id("EstadoDocumentos")));
                select.SelectByText("Aceites");

                query = driver.FindElement(By.Id("Guardar"));
                query.Click();
            }
        }

        [TestMethod]
        public void TesteMarcarEntrevista()
        {
            // Initialize the Firefox Driver
            using (IWebDriver driver = new FirefoxDriver(@"D:\stremio-cache"))
            {
                // 1. Maximize the browser
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://cimobips-001-site1.atempurl.com");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                IWebElement query = driver.FindElement(By.Id("Login"));
                query.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                query = driver.FindElement(By.Id("Email"));
                query.SendKeys("projcimob@gmail.com");
                query = driver.FindElement(By.Id("Password"));
                query.SendKeys("Ips123!");
                query = driver.FindElement(By.Id("Login1"));
                query.Click();

                query = driver.FindElement(By.XPath("//a[contains(text(),'Vasco Da Gama')]"));
                query.Click();

                query = driver.FindElement(By.XPath("//a[contains(text(),'Consultar Candidatura')]"));
                query.Click();

                //query = driver.FindElement(By.Id("passoSeguinte"));
                //query.Click();

                query = driver.FindElement(By.Id("DataDeEntrevista"));
                query.SendKeys("12/05/2018");

                query = driver.FindElement(By.Id("marcarEntrevista"));
                query.Click();
            }
        }

        [TestMethod]
        public void TesteAceitarEntrevista()
        {
            // Initialize the Firefox Driver
            using (IWebDriver driver = new FirefoxDriver(@"D:\stremio-cache"))
            {
                // 1. Maximize the browser
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://cimobips-001-site1.atempurl.com");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                IWebElement query = driver.FindElement(By.Id("Login"));
                query.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                query = driver.FindElement(By.Id("Email"));
                query.SendKeys("cimob@email.com");
                query = driver.FindElement(By.Id("Password"));
                query.SendKeys("Ips123!");
                query = driver.FindElement(By.Id("Login1"));
                query.Click();

                query = driver.FindElement(By.XPath("//input[@value='Gestão de Entrevistas']"));
                query.Click();

                query = driver.FindElement(By.XPath("(//a[contains(text(),'Editar')])[8]"));
                query.Click();

                SelectElement select = new SelectElement(driver.FindElement(By.Id("Estado")));
                select.SelectByText("Aceite");

                query = driver.FindElement(By.Id("Guardar"));
                query.Click();
            }
        }

        [TestMethod]
        public void TesteFaseFinalCandidatura()
        {
            // Initialize the Firefox Driver
            using (IWebDriver driver = new FirefoxDriver(@"D:\stremio-cache"))
            {
                // 1. Maximize the browser
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://cimobips-001-site1.atempurl.com");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                IWebElement query = driver.FindElement(By.Id("Login"));
                query.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                query = driver.FindElement(By.Id("Email"));
                query.SendKeys("projcimob@gmail.com");
                query = driver.FindElement(By.Id("Password"));
                query.SendKeys("Ips123!");
                query = driver.FindElement(By.Id("Login1"));
                query.Click();

                query = driver.FindElement(By.XPath("//a[contains(text(),'Vasco Da Gama')]"));
                query.Click();

                query = driver.FindElement(By.XPath("//a[contains(text(),'Consultar Candidatura')]"));
                query.Click();

                query = driver.FindElement(By.Id("passoSeguinte"));
                query.Click();
            }
        }
    }
}
