using server.Helpers;

namespace server.Models.Inputs
{
    public class InSiteListarCasasFiltro
    {
        ///<summary>
        /// Url Cliente
        ///</summary>
        public string urlCliente { get; set; }

        ///<summary>
        /// Filtro da finalidade
        ///</summary>
        public string finalidade { get; set; }
        
        ///<summary>
        /// Filtro da cidade
        ///</summary>
        public string cidade { get; set; }
        
        ///<summary>
        /// Filtro do endereco
        ///</summary>
        public string endereco { get; set; }
    }
}