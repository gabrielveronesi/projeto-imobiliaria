using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Helpers;
using server.Models.Inputs;
using server.Models.OutPuts;
using server.Repositories;

namespace server.Services
{
    public class SiteService
    {
        private readonly SiteRepository _siteRepository;

        public SiteService(SiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public OutListarDadosClienteSite ListarConfiguracoes(string urlCliente)
        {
            return _siteRepository.ListarConfiguracoes(urlCliente);
        }

        public async Task<List<OutListarCasasClienteSite>> ListarCasas(InListarCasasSite entrada)
        {
             List<OutListarCasasClienteSite> retorno = new List<OutListarCasasClienteSite>();
            
            var casas = await _siteRepository.ListarCasas(entrada);

            PaginaParametros auxPaginaParametros = new PaginaParametros() 
            {
                 PaginaNumero = 1,
                 PaginaTamanho = 99999,
                 Busca = null 
            }; 

            InListarCasasSite auxInListarCasasPainel = new InListarCasasSite() 
            {
                urlCliente = entrada.urlCliente,
                paginaParametros = auxPaginaParametros
            }; 

            var contadorCasa = await _siteRepository.ListarCasas(auxInListarCasasPainel);

            float contador = (int)Math.Ceiling(contadorCasa.Count / (double)entrada.paginaParametros.PaginaTamanho);
            
            foreach (var _casas in casas)
            {
                retorno.Add( new OutListarCasasClienteSite(){
                     idCasa           = _casas.idCasa
                    ,titulo           = _casas.titulo
                    ,pequenaDescricao = _casas.pequenaDescricao
                    ,valor            = _casas.valor
                    ,oculto           = _casas.oculto
                    ,totalPaginas     = contador
                });
            }

            return retorno;
        }

        public async Task<List<OutSiteListarCasasFiltro>> ListarCasasFiltros(InSiteListarCasasFiltro entrada)
        {
            return await _siteRepository.ListarCasasFiltros(entrada);
        }

        public async Task<List<OutSiteListarCasasDestaque>> ListarCasasDestaque(string urlCliente)
        {
            return await _siteRepository.ListarCasasDestaque(urlCliente);
        }

        public async Task<List<OutSiteListarFotosCasa>> ListarFotosCasas(InSiteListarFotosCasa entrada)
        {
            return await _siteRepository.ListarFotosCasas(entrada);
        }

        public async Task<OutSiteConfiguracoesCasa> ListarConfiguracoesCasa(InSiteConfiguracoesCasa entrada)
        {
            return await _siteRepository.ListarConfiguracoesCasa(entrada);
        }
    }
}