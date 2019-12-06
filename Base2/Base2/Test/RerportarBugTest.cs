using Base2.PageObject;
using Base2.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Base2.Test
{
    [TestClass]
    public class RerportarBugTest
    {
        private static IWebDriver driver;
        private Conexao conexao = new Conexao(driver);
        LoginPage login;
        DashBoardPage dashboard;
        SelectProjectPage selecionarProjeto;
        ReportPage reportar;

        [TestInitialize]
        public void ConfiguracaoInicial()
        {
            driver = conexao.ConectarIWebDriver(driver);
            login = new LoginPage(driver);
            dashboard = login.PreencherTodosCampos(driver);
            selecionarProjeto = dashboard.NavegarPara(driver);
            reportar = selecionarProjeto.NavegarPara(driver);
        }

        [TestMethod]
        [TestCategory("Fluxo Principal")]
        public void CriarBug()
        {
            reportar.EscolherCategory("65");
            reportar.EscolherReproducibility("always");
            reportar.EscolherSeverity("crash");
            reportar.EscolherPriority("immediate");
            reportar.EscolherProfile("teste teste teste");
            reportar.PreencherPlatform("Orgrimmar");
            reportar.PreencherOS("Horda");
            reportar.PreencherOsVersion("4.1");
            reportar.PreencherSummary("Teste automacao");
            reportar.PreencherDescription("teeeeeeeeeeeeeeeeeeeeeeeeeeste");
            reportar.PreencherStepsToReproduce("1 - teste");
            reportar.PreencherAdditionalInformation("preenche plz");
            //reportar.CarregarArquivo();
            reportar.EscolherStatus("private");
            reportar.ClicarCheckBox();
            reportar.AcioanrBtnSubmit();
            Assert.IsTrue(reportar.Verificacao("Operation successful."));
        }

        [TestCleanup]
        public void Encerrar()
        {
            driver.Close();
        }

    }
}
