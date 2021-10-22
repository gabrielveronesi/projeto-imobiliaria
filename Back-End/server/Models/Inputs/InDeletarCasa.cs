using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InDeletarCasa
    {
        ///<summary>
        /// Identificador da casa
        ///</summary>
        [Required]
        public int idCasa { get; set; }
    }
}