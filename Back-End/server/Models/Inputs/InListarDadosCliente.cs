using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InListarDadosCliente
    {
        ///<summary>
        /// Identificador do cliente
        ///</summary>
        [Required]
        public int idCliente { get; set; }
    }
}