using server.Helpers;

namespace server.Models.Inputs
{
    public class InSiteConfiguracoesCasa
    {
        ///<summary>
        /// Url Cliente
        ///</summary>
        public string urlCliente { get; set; }

        ///<summary>
        /// Identificador da Casa
        ///</summary>
        public int idCasa { get; set; }
    }
}