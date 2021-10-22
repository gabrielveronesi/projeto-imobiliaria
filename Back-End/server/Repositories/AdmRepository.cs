using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.Models.Entity;
using server.Models.Inputs;
using server.Models.OutPuts;

namespace server.Repositories
{
    public class AdmRepository
    {
        private readonly DataContext _context;
        public AdmRepository(DataContext context)
        {
            _context = context;
        }

        #region Cadastrar cliente
        public async Task<OutCadastroCliente> CadastrarCliente(Cliente parametros)
        {
            OutCadastroCliente retorno = new OutCadastroCliente();

            await _context.Clientes.AddAsync(parametros);
            await _context.SaveChangesAsync();

            retorno.idCliente  = parametros.idCliente;
            retorno.urlCliente = parametros.urlCliente;
            retorno.usuario    = parametros.usuario;
            retorno.senha      = parametros.senha;

            return retorno;
        }

        #endregion Cadastrar cliente

        #region Listar todos os Clientes
        public List<OutListarClientes> ListarClientes()
        {
            List<OutListarClientes> retorno = new List<OutListarClientes>();
            
            IQueryable<Cliente> query = _context.Clientes;

            foreach (var _query in query)
            {
                retorno.Add(new OutListarClientes()
                {
                   idCliente     = _query.idCliente,
                   nomeComercial = _query.nomeComercial,
                   nomeCliente   = _query.nomeCliente,
                   logo          = _query.logo,
                   whatsApp      = _query.whatsApp,
                   telefone      = _query.telefone,
                   email         = _query.email,
                   endereco      = _query.endereco,
                   facebook      = _query.facebook,
                   instagram     = _query.instagram,
                   linkedin      = _query.linkedin,
                   youtube       = _query.youtube,
                   twitter       = _query.twitter,
                   urlCliente    = _query.urlCliente,
                   snAtivo       = _query.snAtivo,
                   usuario       = _query.usuario,
                   senha         = _query.senha
                });
            }

            return retorno;
        }

        #endregion Listar todos os Clientes

        #region Atualizar cliente
        public async Task<OutAtualizarCliente> AtualizarCliente(InAtualizarCliente entrada)
        {
            OutAtualizarCliente retorno = new OutAtualizarCliente();

            var clienteParaAtualizar = await _context.Clientes.FindAsync(entrada.idCliente);

            if (clienteParaAtualizar == null)
            {
                retorno.mensagem = "Não foi possivel localizar o cliente pelo idCliente";
                return retorno;
            }

            _context.Entry(clienteParaAtualizar).CurrentValues.SetValues(entrada); //seta o valor do model para o ESTABELECIMENTO
            _context.Clientes.Update(clienteParaAtualizar);

            await _context.SaveChangesAsync();
            retorno.mensagem = "Cliente atualizado com sucesso!";

            return retorno;
        }

        #endregion Atualizar cliente

        #region Listar Dados Cliente
        public OutListarDadosClienteAdm ListarDadosCliente(InListarDadosCliente parametros)
        {
            var resultado = _context.Clientes.Select(x => new OutListarDadosClienteAdm () { 
                                                     idCliente     = x.idCliente
                                                    ,nomeComercial = x.nomeComercial
                                                    ,nomeCliente   = x.nomeCliente
                                                    ,logo          = x.logo
                                                    ,whatsApp      = x.whatsApp
                                                    ,telefone      = x.telefone
                                                    ,email         = x.email
                                                    ,endereco      = x.endereco
                                                    ,facebook      = x.facebook
                                                    ,instagram     = x.instagram
                                                    ,linkedin      = x.linkedin
                                                    ,youtube       = x.youtube
                                                    ,twitter       = x.twitter
                                                    ,urlCliente    = x.urlCliente
                                                    ,snAtivo       = x.snAtivo
                                                    ,usuario       = x.usuario
                                                    ,senha         = x.senha
                                                    }).Where(x => x.idCliente == parametros.idCliente);
            
            return resultado.FirstOrDefault();
        }

        #endregion Listar Dados Cliente

    }
}