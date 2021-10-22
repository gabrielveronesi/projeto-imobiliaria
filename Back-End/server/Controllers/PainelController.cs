using System.Collections.Generic;
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
    [Route("painel")]
    public class PainelController : ControllerBase
    {
        private readonly PainelService _painelService;
        public PainelController(PainelService painelService)
        {
            _painelService = painelService;
        }

        /// <summary>
        /// Logar no painel administrativo
        /// </summary>
        [HttpPost("logar")]
        public async Task<OutLogarPainel> Logar(InLogarPainel entrada)
        {
            return await _painelService.Logar(entrada);
        }

        /// <summary>
        /// Cadastrar casa
        /// </summary>
        [HttpPost("cadastrar-casa")]
        [Authorize]
        public async Task<OutCadastrarCasa> CadastrarCasa(InCadastrarCasa entrada)
        {
            return await _painelService.CadastrarCasa(entrada);
        }

        /// <summary>
        /// Listar casas do cliente
        /// </summary>
        [HttpPost("listar-casas")]
        public async Task<ActionResult<List<OutListarCasasPainel>>> ListarCasas(InListarCasasPainel entrada)
        {
            return await _painelService.ListarCasas(entrada);
        }

        /// <summary>
        /// Listar dados da casa passando o idCasa
        /// </summary>
        [HttpPost("listar-dados-casas")]
        public async Task<ActionResult<OutListarDadosCasa>> ListarDadosCasa(InListarDadosCasa entrada)
        {
            return await _painelService.ListarDadosCasa(entrada);
        }

        /// <summary>
        /// Atualizar casa
        /// </summary>
        [HttpPut("atualizar-casa")]
        public async Task<OutAtualizarCasa> AtualizarCasa(InAtualizarCasa entrada)
        {
            return await _painelService.AtualizarCasa(entrada);
        }

        /// <summary>
        /// Ocultar casa
        /// </summary>
        [HttpPost("ocultar-casa")]
        public async Task<OutOcultarCasa> OcultarCasa(InOcultarCasa entrada)
        {
            return await _painelService.OcultarCasa(entrada);
        }

        /// <summary>
        /// Excluir casa
        /// </summary>
        [HttpDelete("excluir-casa")]
        public async Task<OutDeletarCasa> ExcluirCasa(InDeletarCasa entrada)
        {
            return await _painelService.ExcluirCasa(entrada);
        }
    }
}