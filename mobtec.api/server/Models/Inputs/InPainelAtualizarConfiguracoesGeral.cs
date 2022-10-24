using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InPainelAtualizarConfiguracoesGeral
    {
        ///<summary>
        /// Identificador do cliente
        ///</summary>
        [Required]
        public int idCliente { get; set; }

        ///<summary>
        /// Nome do estabelecimento
        ///</summary>
        public string nomeComercial { get; set; }

        ///<summary>
        /// Numero do WhatsApp
        ///</summary>
        public string whatsApp { get; set; } 

        ///<summary>
        /// Telefone
        ///</summary>
        public string telefone { get; set; } 

        ///<summary>
        /// Email
        ///</summary>
        public string email { get; set; } 

        ///<summary>
        /// Endereco do estabelecimento
        ///</summary>
        public string endereco { get; set; } 

        ///<summary>
        /// Url Facebook
        ///</summary>
        public string facebook { get; set; } 

        ///<summary>
        /// Instagram
        ///</summary>
        public string instagram { get; set; }

        ///<summary>
        /// Linkedin
        ///</summary>
        public string linkedin { get; set; } 

        ///<summary>
        /// Youtube
        ///</summary>
        public string youtube { get; set; }

        ///<summary>
        /// Twitter
        ///</summary>
        public string twitter { get; set; }
    }
}