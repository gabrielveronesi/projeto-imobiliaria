namespace server.Models.OutPuts
{
    public class OutSiteConfiguracoesCasa
    {
        ///<summary>
        /// Identificador da casa/referencia
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
        /// Endereco
        ///</summary>
        public string endereco { get; set; }
        
        ///<summary>
        /// Cidade
        ///</summary>
        public string cidade { get; set; }

        ///<summary>
        /// Tipo - Locação / Venda
        ///</summary>
        public string tipo { get; set; }

        ///<summary>
        /// Descrição
        ///</summary>
        public string descricao { get; set; }

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