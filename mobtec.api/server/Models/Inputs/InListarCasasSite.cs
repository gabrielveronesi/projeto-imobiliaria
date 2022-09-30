using server.Helpers;

namespace server.Models.Inputs
{
    public class InListarCasasSite
    {
        ///<summary>
        /// Url Cliente
        ///</summary>
        public string urlCliente { get; set; }

        ///<summary>
        /// Paramentros de entrada para a paginação
        ///</summary>
        public PaginaParametros paginaParametros { get; set; }
    }
}