using OpenQA.Selenium;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace Base2.Util
{
    public class GerarRandom
    {
        public static string GerarCpf()
        {
            var random = new Random();
            string semente;

            do
            {
                semente = random.Next(1, 999999999).ToString().PadLeft(9, '0');
            }
            while (
                   semente == "000000000"
                || semente == "111111111"
                || semente == "222222222"
                || semente == "333333333"
                || semente == "444444444"
                || semente == "555555555"
                || semente == "666666666"
                || semente == "777777777"
                || semente == "888888888"
                || semente == "999999999"
            );

            semente += CalcularDigitoVerificador(semente).ToString();
            semente += CalcularDigitoVerificador(semente).ToString();
            return semente;
        }

        public static int CalcularDigitoVerificador(string semente)
        {
            int soma = 0;
            int resto = 0;
            int[] multiplicadores = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int iFinal = multiplicadores.Count();
            var iInicial = iFinal - semente.Count();

            for (int i = iInicial; i < iFinal; i++)
            {
                soma += int.Parse(semente[i - iInicial].ToString()) * multiplicadores[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            return resto;
        }

        public static string GerarNome(int tamanho)
        {
            /**
             * Codigo tirado do site /https://codereview.stackexchange.com/questions/146916/pronounceable-nome-generator
             */
            const string vogal = "aeiou";
            const string consoante = "bcdfghjklmnpqrstvwxyz";

            var rnd = new Random();
            var Nome = new StringBuilder();

            tamanho = tamanho % 2 == 0 ? tamanho : tamanho + 1;

            for (var i = 0; i < tamanho / 2; i++)
            {
                Nome
                    .Append(vogal[rnd.Next(vogal.Length)])
                    .Append(consoante[rnd.Next(consoante.Length)]);
            }

            var SobreNome = new StringBuilder();
            for (var i = 0; i < tamanho / 2; i++)
            {
                SobreNome
                    .Append(vogal[rnd.Next(vogal.Length)])
                    .Append(consoante[rnd.Next(consoante.Length)]);
            }

            String NomeCompleto = Nome.ToString() + " " + SobreNome.ToString();

            return NomeCompleto;
        }

        public static string GerarEmail(string nome)
        {
            string email = nome.Replace(" ", "") + "@teste.com";
            return email;
        }

        public static string GerarUsuario(string nome)
        {
            string usuario;

            usuario = nome.Replace(" ", ".");

            return usuario;
        }

        public static string GerarSenha()
        {
            Random random = new Random();

            int TamanhoArrayCaracteres;

            String[] caracteres = { "0", "1", "b", "2", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g",
                                    "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
                                    "y", "z", "#", "$", "@", "%", "&", "*", "A", "B", "C", "D", "E", "F", "G", "H", "I",
                                    "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "W", "Y", "Z"};

            String[] caracterEspecil = { "!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "=", "[", "]", "/", "+" };

            String[] caracterMaiusculo = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                          "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "W", "Y", "Z"};
            String[] caracterNumerico = { "0", "1", "b", "2", "4", "5", "6", "7", "8", "9" };

            StringBuilder senha = new StringBuilder();

            TamanhoArrayCaracteres = caracteres.Length;

            for (int i = 0; i < 4; i++)
            {
                int posicaoDentroArray = random.Next(TamanhoArrayCaracteres);
                senha.Append(caracteres[posicaoDentroArray]);
            }

            TamanhoArrayCaracteres = caracterEspecil.Length;
            int posicaoDentroArray5 = random.Next(TamanhoArrayCaracteres);
            senha.Append(caracterEspecil[posicaoDentroArray5]);

            TamanhoArrayCaracteres = caracterMaiusculo.Length;
            int posicaoDentroArray6 = random.Next(TamanhoArrayCaracteres);
            senha.Append(caracterMaiusculo[posicaoDentroArray6]);

            TamanhoArrayCaracteres = caracterNumerico.Length;
            int posicaoDentroArray7 = random.Next(TamanhoArrayCaracteres);
            senha.Append(caracterNumerico[posicaoDentroArray7]);

            return senha.ToString();
        }

        public static String EscolherPosicaoArray(String[] Lista)
        {
            Random random = new Random();
            String ItemSorteado;
            int TamanhoArray;
            TamanhoArray = Lista.Length;
            int posicaoDentroArray = random.Next(TamanhoArray);
            ItemSorteado = (Lista[posicaoDentroArray]);
            return ItemSorteado;
        }

    }

}
