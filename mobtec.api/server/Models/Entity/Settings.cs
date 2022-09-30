using System.ComponentModel.DataAnnotations;

namespace server.Models.Entity
{
    public class Settings
    {
        public static string Secret = "SHHHHHHHHISSOEUMTOKENSECRETO";
        public int ExpiracaoHoras { get; set; }
    }
}