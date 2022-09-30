using System.ComponentModel.DataAnnotations;

namespace server.Models.Inputs
{
    public class InOcultarCasa
    {
        ///<summary>
        /// Identificador da casa
        ///</summary>
        [Required]
        public int idCasa { get; set; }
    }
}