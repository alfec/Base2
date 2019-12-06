using Base2.Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2.PageObject
{
    class LoginPage
    {
        public IWebDriver driver;
        MetodosGenericos campo = new MetodosGenericos();

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///<summary>
        ///Botões mapeados mesmo que não há a utilização dos mesmo no teste
        /// </summary>
        public IWebElement CampoLogin               => driver.FindElement(By.CssSelector("html body div form table.width50 tbody tr.row-1 td input"));
        public IWebElement CampoSenha               => driver.FindElement(By.CssSelector("html body div form table.width50 tbody tr.row-2 td input"));
        public IWebElement CheckBoxLembrarLogin     => driver.FindElement(By.CssSelector("tr.row-1:nth-child(4) > td:nth-child(2) > input:nth-child(1)"));
        public IWebElement CheckBoxSecureSession    => driver.FindElement(By.CssSelector("html body div form table.width50 tbody tr.row-2 td input"));
        public IWebElement BtnLogin                 => driver.FindElement(By.CssSelector("html body div form table.width50 tbody tr td.center input.button"));
        public IWebElement LinkEsqueciSenha         => driver.FindElement(By.CssSelector("html body div span.bracket-link a"));

        public void PreencherLogin(String login)
        {
            campo.PreencherCampo(CampoLogin, login);
        }

        public void PreencherSenha(String Senha)
        {
            campo.PreencherCampo(CampoSenha, Senha);
        }

        public void ClicarCheckBoxLembrarLogin()
        {
            campo.ClicaUmaVez(CheckBoxLembrarLogin);
        }

        public void ClicarCheckBoxSecureSession()
        {
            campo.ClicaUmaVez(CheckBoxSecureSession);
        }

        public void AcionarBtnLogin()
        {
            campo.ClicaUmaVez(BtnLogin);
        }

        public void AcionarEsqueciSenha()
        {
            campo.ClicaUmaVez(LinkEsqueciSenha);
        }

        public DashBoardPage NavegarParaDashBoard(IWebDriver driver)
        {
            campo.ClicaUmaVez(BtnLogin);
            return new DashBoardPage(driver);
        }
        
        public DashBoardPage PreencherTodosCampos(IWebDriver driver)
        {
            campo.PreencherCampo(CampoLogin, "andre.ferreira");
            campo.PreencherCampo(CampoSenha, "1573ALfc");
            campo.ClicaUmaVez(BtnLogin);
            return new DashBoardPage(driver);
        }

    }
}
