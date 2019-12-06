using Base2.PageObject;
using Base2.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Base2
{
    [TestClass]
    public class LoginTest
    {
        private static IWebDriver driver;
        private Conexao conexao = new Conexao(driver);
        LoginPage login;
        DashBoardPage dashboard;

        [TestInitialize]
        public void ConfiguracaoInicial()
        {
            driver = conexao.ConectarIWebDriver(driver);
            login = new LoginPage(driver);
        }

        [TestMethod]
        [TestCategory("Fluxo Principal")]
        public void FazerLoginNoSistema()
        {
            login.PreencherLogin("andre.ferreira");
            login.PreencherSenha("1573ALfc");
            login.ClicarCheckBoxLembrarLogin();
            dashboard = login.NavegarParaDashBoard(driver);
            Assert.IsTrue(dashboard.Verificacao("andre.ferreira"));
        }

        [TestCleanup]
        public void Encerrar()
        {
            driver.Close();
        }

    }
}
