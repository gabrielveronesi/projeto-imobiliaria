using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InCadastrarCasa
    {
        ///<summary>
        /// Identificador do cliente que está cadastrando a casa
        ///</summary>
        [Required]
        public int idCliente { get; set; }

        ///<summary>
        /// Titulo
        ///</summary>
        [Required]
        public string titulo { get; set; }

        ///<summary>
        /// Uma breve descrição para exibir no index
        ///</summary>
        [Required]
        public string pequenaDescricao { get; set; }

        ///<summary>
        /// Endereco
        ///</summary>
        [Required]
        public string endereco { get; set; }
        
        ///<summary>
        /// Cidade
        ///</summary>
        [Required]
        public string cidade { get; set; }

        ///<summary>
        /// Tipo - Locação / Venda
        ///</summary>
        [Required]
        public string tipo { get; set; }

        ///<summary>
        /// Descrição
        ///</summary>
        [Required]
        public string descricao { get; set; }

        ///<summary>
        /// Uma breve descrição para exibir no index
        ///</summary>
        [Required]
        public int valor { get; set; }

    }
}