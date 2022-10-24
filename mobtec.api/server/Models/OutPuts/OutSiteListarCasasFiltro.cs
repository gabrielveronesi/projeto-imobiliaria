namespace server.Models.OutPuts
{
    public class OutSiteListarCasasFiltro
    {
        ///<summary>
        /// Identificador da casa
        ///</summary>
        public int idCasa { get; set; }

        ///<summary>
        /// Titulo
        ///</summary>
        public string titulo { get; set; }

        ///<summary>
        /// Uma breve descrição para exibir no index
        ///</summary>
        public string pequenaDescricao { get; set; }

        ///<summary>
        /// Uma breve descrição para exibir no index
        ///</summary>
        public int valor { get; set; }

        ///<summary>
        /// Oculto ou não
        ///</summary>
        public string oculto { get; set; }
    }
}