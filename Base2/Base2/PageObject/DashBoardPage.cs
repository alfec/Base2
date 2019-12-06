using Base2.Util;
using OpenQA.Selenium;

namespace Base2.PageObject
{
    public class DashBoardPage
    {
        private IWebDriver driver;
        MetodosGenericos campo = new MetodosGenericos();

        public DashBoardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///<summary>
        ///Botões mapeados mesmo que não há a utilização dos mesmo no teste
        /// </summary>

        public IWebElement LinkMyView       => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(1)"));
        public IWebElement LinkViewIssues   => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(2)"));
        public IWebElement LinkReport       => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(3)"));
        public IWebElement LinkChangeLog    => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(4)"));
        public IWebElement LinkRoadmap      => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(5)"));
        public IWebElement LinkMyAccount    => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(6)"));
        public IWebElement LinkLogout       => driver.FindElement(By.CssSelector("td.menu:nth-child(1) > a:nth-child(7)"));
        public IWebElement InputNumMantis   => driver.FindElement(By.CssSelector("input.small"));
        public IWebElement SelectProjetos   => driver.FindElement(By.CssSelector("select.small"));
        public IWebElement BtnSwitch        => driver.FindElement(By.CssSelector("td.menu:nth-child(2) > form:nth-child(1) > input:nth-child(2)"));
        public IWebElement BtnJump          => driver.FindElement(By.CssSelector(".login-info-right > form:nth-child(1) > input:nth-child(2)"));
        public IWebElement ValidarLogin     => driver.FindElement(By.CssSelector(".login-info-left"));

        public SelectProjectPage NavegarPara(IWebDriver driver)
        {
            ///<summary>
            ///Caso a automação fosse feita para regressão eu criaria 1 metodo para cada botão que trocasse de pagina
            ///e com isso criaria uma PageObject relacionada
            /// </summary>
            campo.ClicaUmaVez(LinkReport);
            return new SelectProjectPage(driver);
        }

        public bool Verificacao(string TextoParaVerificar)
        {
            return campo.VerificarTextoTela(ValidarLogin, TextoParaVerificar);
        }
    }
}