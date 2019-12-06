using Base2.Util;
using OpenQA.Selenium;

namespace Base2.PageObject
{
    public class ReportPage
    {
        private IWebDriver driver;
        MetodosGenericos campo = new MetodosGenericos();

        public ReportPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Mapeamento dos selects Enter Report Details 
        public IWebElement SelectCategory        => driver.FindElement(By.CssSelector("tr.row-1:nth-child(2) > td:nth-child(2) > select:nth-child(1)"));
        public IWebElement SelectReproducibility => driver.FindElement(By.CssSelector("tr.row-2:nth-child(3) > td:nth-child(2) > select:nth-child(1)"));
        public IWebElement SelectSeverity        => driver.FindElement(By.CssSelector("tr.row-1:nth-child(4) > td:nth-child(2) > select:nth-child(1)"));
        public IWebElement SelectPriority        => driver.FindElement(By.CssSelector("tr.row-2:nth-child(5) > td:nth-child(2) > select:nth-child(1)"));
        public IWebElement SelectProfile         => driver.FindElement(By.CssSelector("tr.row-1:nth-child(6) > td:nth-child(2) > select:nth-child(1)"));

        //Mapeamento dos itens de versão
        public IWebElement Platform  => driver.FindElement(By.Id("platform"));
        public IWebElement OS        => driver.FindElement(By.Id("os"));
        public IWebElement OSVersion => driver.FindElement(By.Id("os_build"));


        //Mapeamento dos campos de texto
        public IWebElement Summary               => driver.FindElement(By.CssSelector("tr.row-2:nth-child(8) > td:nth-child(2) > input:nth-child(1)"));
        public IWebElement Description           => driver.FindElement(By.CssSelector("tr.row-1:nth-child(9) > td:nth-child(2) > textarea:nth-child(1)"));
        public IWebElement StepsToReproduce      => driver.FindElement(By.CssSelector("tr.row-2:nth-child(10) > td:nth-child(2) > textarea:nth-child(1)"));
        public IWebElement AdditionalInformation => driver.FindElement(By.CssSelector("tr.row-1:nth-child(11) > td:nth-child(2) > textarea:nth-child(1)"));

        //Mapeamento dos demais campos
        public IWebElement BtnBrowse          => driver.FindElement(By.Id("ufile[]"));
        public IWebElement ViewStatusPrivate  => driver.FindElement(By.CssSelector("tr.row-1:nth-child(13) > td:nth-child(2) > label:nth-child(2) > input:nth-child(1)"));
        public IWebElement ViewStatusPublic   => driver.FindElement(By.CssSelector("tr.row-1:nth-child(13) > td:nth-child(2) > label:nth-child(1) > input:nth-child(1)"));
        public IWebElement CheckBoxReportStay => driver.FindElement(By.Id("report_stay"));
        public IWebElement BtnSubmit          => driver.FindElement(By.CssSelector("html body div form table.width90 tbody tr td.center input.button"));
        public IWebElement ValidarTexto       => driver.FindElement(By.CssSelector("body > div:nth-child(5)"));

        public void PreencherPlatform(string plataforma)
        {
            campo.PreencherCampo(Platform, plataforma);
        }
        
        public void PreencherOS(string Os)
        {
            campo.PreencherCampo(OS, Os);
        }
        
        public void PreencherOsVersion(string VersaoOS)
        {
            campo.PreencherCampo(OSVersion, VersaoOS);
        }
        
        public void PreencherSummary(string Resumo)
        {
            campo.PreencherCampo(Summary, Resumo);
        }
        
        public void PreencherDescription(string Descricao)
        {
            campo.PreencherCampo(Description, Descricao);
        }
        
        public void PreencherStepsToReproduce(string Steps)
        {
            campo.PreencherCampo(StepsToReproduce, Steps);
        }
        
        public void PreencherAdditionalInformation(string Informacao)
        {
            campo.PreencherCampo(AdditionalInformation, Informacao);
        }
        
        public void CarregarArquivo()
        {
            campo.PreencherCampo(BtnBrowse, "");
        }
        
        public void EscolherStatus(string Status)
        {
            if (Status == "public")
            {
                campo.ClicaUmaVez(ViewStatusPublic);
            }
            else
            {
                campo.ClicaUmaVez(ViewStatusPrivate);

            }
        }
        
        public void ClicarCheckBox()
        {
            campo.ClicaUmaVez(CheckBoxReportStay);
        }
        
        public void AcioanrBtnSubmit()
        {
            campo.ClicaUmaVez(BtnSubmit);
        }

        public void EscolherCategory(string Categoria)
        {
            campo.SelecionaListaTexto(SelectCategory, false, Categoria);
        }
        
        public void EscolherReproducibility(string Reproduzir)
        {
            campo.SelecionaListaTexto(SelectReproducibility, true, Reproduzir);
        }
        
        public void EscolherSeverity(string Severidade)
        {
            campo.SelecionaListaTexto(SelectSeverity, true, Severidade);
        }
        
        public void EscolherPriority(string Prioridade)
        {
            campo.SelecionaListaTexto(SelectPriority, true, Prioridade);
        }
        
        public void EscolherProfile(string Perfil)
        {
            campo.SelecionaListaTexto(SelectProfile, true, Perfil);
        }

        public bool Verificacao(string TextoParaVerificar)
        {
            return campo.VerificarTextoTela(ValidarTexto, TextoParaVerificar);

        }

    }
}