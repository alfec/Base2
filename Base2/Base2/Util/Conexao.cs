using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Base2.Util
{
    public class Conexao
    {
        private IWebDriver browser;

        public Conexao(IWebDriver driver)
        {
            this.browser = driver;
        }

        public IWebDriver ConectarIWebDriver(IWebDriver driver)
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://mantis-prova.base2.com.br/login_page.php");
            return browser;
        }

    }
}
