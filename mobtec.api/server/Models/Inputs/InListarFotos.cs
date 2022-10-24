using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InListarFotos
    {
        ///<summary>
        /// Identificador da casa
        ///</summary>
        public int idCasa { get; set; }

        ///<summary>
        /// Identificador do cliente
        ///</summary>
        public int idCliente { get; set; }
    }
}