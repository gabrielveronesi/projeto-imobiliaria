using server.Helpers;

namespace server.Models.Inputs
{
    public class InListarCasasPainel
    {
        ///<summary>
        /// Identificador do cliente
        ///</summary>
        public int idCliente { get; set; }

        ///<summary>
        /// Paramentros de entrada para a paginação
        ///</summary>
        public PaginaParametros paginaParametros { get; set; }
    }
}