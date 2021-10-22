using System;

namespace server.Helpers
{
    public static class GerarSenha
    {
        public static string NovaSenha()
        {
            // Gera uma senha com 6 caracteres entre numeros e letras
            string chars = "bcdefghjkmnpqrstuvwxyz023456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 6; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }

            return pass;
        }
    }
}