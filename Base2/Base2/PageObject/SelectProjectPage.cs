using Base2.Util;
using OpenQA.Selenium;

namespace Base2.PageObject
{
    public class SelectProjectPage
    {
        private IWebDriver driver;
        MetodosGenericos campo = new MetodosGenericos();

        public SelectProjectPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// deveria ser feito o mapeamento dos Links para outras telas
        /// Mas como não vou usa-los no teste em questão, não vou mapea-los
        /// </summary>
        public IWebElement SelectEscolherProjeto => driver.FindElement(By.CssSelector(".row-1 > td:nth-child(2) > select:nth-child(1)"));
        public IWebElement CheckBoxMarcarDefault => driver.FindElement(By.CssSelector(".row-2 > td:nth-child(2) > input:nth-child(1)"));
        public IWebElement BtnSelectProject      => driver.FindElement(By.CssSelector(".button"));

        public void EscolherProjeto(string NomeProjeto)
        {
            campo.SelecionaListaTexto(SelectEscolherProjeto, true, NomeProjeto);
        }
        
        public void ClicarCheckBox()
        {
            campo.ClicaUmaVez(CheckBoxMarcarDefault);
        }
        
        public void AcionarBtnSelectProject()
        {
            campo.ClicaUmaVez(BtnSelectProject);
        }
        
        public ReportPage NavegarPara(IWebDriver driver)
        {
            campo.ClicaUmaVez(BtnSelectProject);
            return new ReportPage(driver);
        }



    }
}