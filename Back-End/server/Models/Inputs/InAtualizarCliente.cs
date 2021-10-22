using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InAtualizarCliente
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
        /// Nome do cliente contratante
        ///</summary>
        public string nomeCliente { get; set; } 

        ///<summary>
        /// Logo
        ///</summary>
        public string logo { get; set; } 

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

        ///<summary>
        /// Url do site do cliente
        ///</summary>
        public string urlCliente { get; set; }

        ///<summary>
        /// Usuario para logar no painel do cliente
        ///</summary>
        [Required]
        public string usuario { get; set; }

        ///<summary>
        /// Senha para logar no painel do cliente
        ///</summary>
        [Required]
        public string senha { get; set; }

        ///<summary>
        /// Flag [S - Ativo] / [N - Desativado]
        ///</summary>
        [Required]
        public string snAtivo { get; set; }



        
        
    }
}