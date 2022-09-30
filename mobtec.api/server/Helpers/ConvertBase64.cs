using System;

namespace server.Helpers
{
    public class ConvertBase64
    {
        public static byte[] ConvertFromBase64String(string input)
        {
            try
            {
                string working = input.Replace('-', '+').Replace('_', '/');
                while (working.Length % 3 != 0)
                {
                    working += '=';
                }
                try
                {
                    return Convert.FromBase64String(working);
                }
                catch (Exception)
                {
                    try
                    {
                        return Convert.FromBase64String(input.Replace('-', '+').Replace('_', '/'));
                    }
                    catch (Exception) { }
                    try
                    {
                        return Convert.FromBase64String(input.Replace('-', '+').Replace('_', '/') + "=");
                    }
                    catch (Exception) { }
                    try
                    {
                        return Convert.FromBase64String(input.Replace('-', '+').Replace('_', '/') + "==");
                    }
                    catch (Exception) { }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}