using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Helpers
{
    public class PaginaLista<T> : List<T> //vou paginar uma lista de itens, então vou herdar o list
    {
        public int PaginaAtual { get; set; }
        public int PaginasTotal { get; set; }
        public int PaginaTamanho { get; set; }
        public int ContaTotal { get; set; } //quantos itens no total eu tenho.

        public PaginaLista(List<T> items, int contar, int paginaNumero, int paginaTamanho)// o q eu to listando, quantos itens tem nessa lista, qual que é o n° da pagina, e o tamanho da pagina.
        {
            ContaTotal = contar;
            PaginaTamanho = paginaTamanho;
            PaginaAtual = paginaNumero;
            PaginasTotal = (int)Math.Ceiling(contar / (double)paginaTamanho);
            this.AddRange(items); //para adicionar varios itens da list
        }

        public static async Task<PaginaLista<T>> CreateAsync(
            IQueryable<T> source, int paginaNumero, int paginaTamanho) //recebendo um source

        {
            var contar = await source.CountAsync();
            var items = await source.Skip((paginaNumero - 1) * paginaTamanho)
                                    .Take(paginaTamanho)
                                    .ToListAsync();

            return new PaginaLista<T>(items, contar, paginaNumero, paginaTamanho);
        }
    }
}