using System;
using System.Text.RegularExpressions;

namespace server.Helpers
{
    public static class GerarUrl
    {
        public static string Gerar(bool check, string nomeImobiliaria)
        { 

            if (check) //TRUE, PODE CRIAR A URL NORMAL
            {
                nomeImobiliaria = nomeImobiliaria.Replace(" ", "-")
                                                 .Replace("!", "")
                                                 .Replace(":", "")
                                                 .Replace("ç", "c");

                //tirando emojis!
                string text = nomeImobiliaria;
                string result = Regex.Replace(text, @"\p{Cs}", "");

                return result.ToLower();
            }
            else //FALSE, CRIAR A URL PERSONALIZADA
            {
                nomeImobiliaria = nomeImobiliaria.Replace(" ", "-")
                                                 .Replace("!", "")
                                                 .Replace(":", "")
                                                 .Replace("ç", "c");

                Random randNum = new Random();
                var num = randNum.Next(); //numero aleatorio

                string Manipulation = nomeImobiliaria + num;

                //tirando emojis!
                string text = Manipulation;
                string result = Regex.Replace(text, @"\p{Cs}", "");

                return result.ToLower();
            }
        }
    }
}