namespace server.Models.OutPuts
{
    public class OutCadastroCliente
    {
        ///<summary>
        /// Identificador do cliente
        ///</summary>
        public int idCliente { get; set; }

        ///<summary>
        /// Url do site do cliente
        ///</summary>
        public string urlCliente { get; set; }

        ///<summary>
        /// Usuario para logar no painel do cliente
        ///</summary>
        public string usuario { get; set; }

        ///<summary>
        /// Senha para logar no painel do cliente
        ///</summary>
        public string senha { get; set; }
    }
}