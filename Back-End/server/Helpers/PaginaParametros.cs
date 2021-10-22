namespace server.Helpers
{
    public class PaginaParametros
    {
        public const int MaxPaginaTamanho = 999999999;
        public int PaginaNumero { get; set; } = 1;
        private int paginaTamanho = 999999999;
        public int PaginaTamanho
        {
            get { return paginaTamanho; }
            set { paginaTamanho = (value > MaxPaginaTamanho) ? MaxPaginaTamanho : value; }
        }   

        public string Busca { get; set; } = string.Empty;
    }
}