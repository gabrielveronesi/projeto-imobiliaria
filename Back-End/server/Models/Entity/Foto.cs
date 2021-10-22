namespace server.Models.Entity
{
    public class Foto
    {
        ///<summary>
        /// Identificador da foto
        ///</summary>
        public int idFoto { get; set; }

        ///<summary>
        /// Identificador da casa
        ///</summary>
        public int idCasa { get; set; }

        ///<summary>
        /// Url da imagem
        ///</summary>
        public string urlFoto { get; set; }
    }
}