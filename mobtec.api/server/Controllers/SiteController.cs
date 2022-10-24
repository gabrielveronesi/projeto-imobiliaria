using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models.Entity;
using server.Models.Inputs;
using server.Models.OutPuts;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("site")]
    public class SiteController : ControllerBase
    {
        private readonly SiteService _siteService;
        public SiteController(SiteService siteService)
        {
            _siteService = siteService;
        }

        /// <summary>
        /// Listar as configurações do cliente passando a url do cliente
        /// </summary>
        [HttpGet("listar-configuracoes/{urlCliente}")]
        public OutListarDadosClienteSite ListarConfiguracoes(string urlCliente)
        {
            return _siteService.ListarConfiguracoes(urlCliente);
        }

        /// <summary>
        /// Listar as casas do cliente passando a url do cliente
        /// </summary>
        [HttpPost("listar-casas-site")]
        public async Task<List<OutListarCasasClienteSite>> ListarCasas(InListarCasasSite entrada)
        {
            return await _siteService.ListarCasas(entrada);
        }

        /// <summary>
        /// Listar as casas do cliente passando a url do cliente com os filtros 
        /// </summary>
        [HttpPost("listar-casas-filtro")]
        public async Task<List<OutSiteListarCasasFiltro>> ListarCasasFiltros(InSiteListarCasasFiltro entrada)
        {
            return await _siteService.ListarCasasFiltros(entrada);
        }

        /// <summary>
        /// Listar as casas em destque passando a url do cliente
        /// </summary>
        [HttpPost("listar-casas-destaque")]
        public async Task<List<OutSiteListarCasasDestaque>> ListarCasasDestaque(string urlCliente)
        {
            return await _siteService.ListarCasasDestaque(urlCliente);
        }

        /// <summary>
        /// Listar as fotos da casa
        /// </summary>
        [HttpPost("listar-fotos-casa")]
        public async Task<List<OutSiteListarFotosCasa>> ListarFotosCasas(InSiteListarFotosCasa entrada)
        {
            return await _siteService.ListarFotosCasas(entrada);
        }

        /// <summary>
        /// Listar configurações da casa
        /// </summary>
        [HttpPost("listar-configuracoes-casa")]
        public async Task<OutSiteConfiguracoesCasa> ListarConfiguracoesCasa(InSiteConfiguracoesCasa entrada)
        {
            return await _siteService.ListarConfiguracoesCasa(entrada);
        }
    }
}