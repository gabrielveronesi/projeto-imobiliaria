using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InLogarPainel
    {
        ///<summary>
        /// Usuario do painel administrativo
        ///</summary>
        [Required]
        public string usuario { get; set; }

        ///<summary>
        /// Senha
        ///</summary>
        [Required]
        public string senha { get; set; } 
    }
}