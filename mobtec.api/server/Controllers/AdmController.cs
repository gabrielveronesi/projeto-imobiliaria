using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models.Inputs;
using server.Models.OutPuts;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("adm")]
    public class AdmController : ControllerBase
    {
        private readonly AdmService _admService;
        public AdmController(AdmService admService)
        {
            _admService = admService;
        }

        /// <summary>
        /// Logar no painel administrativo
        /// </summary>
        [HttpPost("logar")]
        public OutLogarAdm Logar(InLogarAdm entrada)
        {
            return _admService.Logar(entrada);
        }

        /// <summary>
        /// Cadastrar cliente
        /// </summary>
        [HttpPost("cadastrar-cliente")]
        public async Task<OutCadastroCliente> CadastrarCliente(InCadastroCliente entrada)
        {
            return await _admService.CadastrarCliente(entrada);
        }

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        [HttpGet("listar-clientes")]
        public List<OutListarClientes> ListarClientes()
        {
            return _admService.ListarClientes();
        }

        /// <summary>
        /// Atualizar cliente
        /// </summary>
        [HttpPut("atualizar-cliente")]
        public async Task<OutAtualizarCliente> AtualizarCliente(InAtualizarCliente entrada)
        {
            return await _admService.AtualizarCliente(entrada);
        }

        /// <summary>
        /// Listar dados do cliente passando o idCliente
        /// </summary>
        [HttpPost("listar-dados-clientes")]
        public OutListarDadosClienteAdm ListarDadosCliente(InListarDadosCliente entrada)
        {
            
            return _admService.ListarDadosCliente(entrada);
        }
    }
}