namespace server.Models.OutPuts
{
    public class OutLogarPainel
    {
        ///<summary>
        /// Boleando de Sucesso
        ///</summary>
        public bool sucesso { get; set; }

        ///<summary>
        /// Mensagem de retorno
        ///</summary>
        public string mensagem { get; set; }

        ///<summary>
        /// Token
        ///</summary>
        public string token { get; set; }

        ///<summary>
        /// Identificador do cliente logado
        ///</summary>
        public int? idCliente { get; set; }
    }
}