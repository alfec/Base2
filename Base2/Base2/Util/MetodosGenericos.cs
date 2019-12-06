using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Collections.Generic;
using System.Text;


namespace Base2.Util
{
    public class MetodosGenericos
    {
        public void ClicaUmaVez(IWebElement elemento)
        {
            elemento.Click();
        }

        public void ClicaDuasVezes(IWebElement elemento)
        {
            new Actions(_driver).DoubleClick(elemento).Perform();
        }

        public void PreencherCampo(IWebElement campo, string texto)
        {
            campo.SendKeys(texto);
        }

        public void PreencherCampoComEnter(IWebElement campo, string texto)
        {
            campo.SendKeys(texto);
            campo.SendKeys(Keys.Enter);
        }

        public void SelecionaListaIndex(IWebElement lista, int item)
        {
            SelectElement selecionarItem = new SelectElement(lista);
            selecionarItem.SelectByIndex(item);
        }

        public void SelecionaListaTexto(IWebElement lista, bool textOuValue, string item)
        {
            //metodo usado para escolher o item dentro do Select pelo texto (SelectByText) ou pelo Value do elemento (SelectByValue) 
            SelectElement selecionarItem = new SelectElement(lista);
            if (textOuValue == true)
            {
                selecionarItem.SelectByText($"{item}");
            }
            else
            {
                selecionarItem.SelectByValue($"{item}");
            }

        }

        public void Navegar(IWebDriver driver, String url)
        {
            driver.Navigate().GoToUrl($"{url}");
        }

        public bool VerificarTextoTela(IWebElement elemento, string msg)
        {
            /// <summary>
            /// Metodo criado para verificar se há uma frase/texto presente na tela
            /// </summary>

            bool textoIgual = false;

            if (elemento.Displayed)
            {
                string texto = elemento.Text;

                if (texto.Contains(msg))
                {
                    return textoIgual = true;
                }
                return textoIgual;
            }
            else
            {
                return textoIgual;
            }
        }

        public static void Esperar(IWebDriver driver, int segundos)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(segundos);
        }

        public bool VerificarCampoNuloOuBranco(IWebElement elemento)
        {
            /// <summary>
            /// Metodo criado para verificar se algum campo está em branco
            /// Cria uma variavel generica e atribue o elemento em questão e pega seu valor
            /// Após fazer isso verifica se ele está nulo ou em branco e retorna o resultado
            /// </summary>

            var campo = elemento.GetAttribute("value");

            if (string.IsNullOrEmpty(campo))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }

}
