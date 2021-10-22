using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Helpers;
using server.Models.Entity;
using server.Models.Inputs;
using server.Models.OutPuts;
using server.Utils;

namespace server.Repositories
{
    public class PainelRepository
    {
        private readonly DataContext _context;
        public PainelRepository(DataContext context)
        {
            _context = context;
        }

        #region Logar no painel administrativo
        public async Task<OutLogarPainel> Logar(InLogarPainel parametros)
        {
            OutLogarPainel retorno = new OutLogarPainel();

            var usuarioCadastrado = _context.Clientes
                                   .Include(c => c.usuario)
                                   .Include(c => c.senha)
                                   .Where(c => c.usuario == parametros.usuario)
                                   .Where(c => c.senha == parametros.senha)
                                   .FirstOrDefault();

            await _context.SaveChangesAsync();

            if (usuarioCadastrado == null)
            {
                retorno.mensagem = "Usuario ou senha inválida!";
                retorno.sucesso = false;
                retorno.token = null;
                retorno.idCliente = null;

                return retorno;
            }
            else if (usuarioCadastrado.snAtivo != "S")
            {
                retorno.mensagem = "Usuario não está ativo!";
                retorno.sucesso = false;
                retorno.token = null;
                retorno.idCliente = null;

                return retorno;
            }
            else
            {
                var token = Token.Gerar(parametros.usuario);
                retorno.mensagem = "Login efetuado com sucesso! ()";
                retorno.sucesso = true;
                retorno.token = token;
                retorno.idCliente = usuarioCadastrado.idCliente;

                return retorno;
            }
        }

        #endregion Logar no painel administrativo

        #region Cadastrar Casa
        public async Task<OutCadastrarCasa> CadastrarCasa(Casa parametros)
        {
            OutCadastrarCasa retorno = new OutCadastrarCasa();

            await _context.Casas.AddAsync(parametros);
            await _context.SaveChangesAsync();

            retorno.idCasa = parametros.idCasa;

            return retorno;
        }

        #endregion Cadastrar Casa

        #region Listar Casas
        public Task<PaginaLista<Casa>> ListarCasas(InListarCasasPainel parametros)
        {
        
            IQueryable<Casa> query = _context.Casas;

            query = query.AsNoTracking().OrderBy(a => a.idCasa)
                                        .Where(a => a.idCliente == parametros.idCliente);

            if (!string.IsNullOrEmpty(parametros.paginaParametros.Busca))
                query = query.Where(casa => casa.titulo
                                                 .ToUpper()
                                                 .Contains(parametros.paginaParametros.Busca.ToUpper()) ||
                                            casa.pequenaDescricao
                                                 .ToUpper()
                                                 .Contains(parametros.paginaParametros.Busca.ToUpper()) ||
                                            casa.idCasa.ToString()
                                                 .ToUpper()
                                                 .Contains(parametros.paginaParametros.Busca.ToUpper()) ||
                                            casa.cidade
                                                 .ToUpper()
                                                 .Contains(parametros.paginaParametros.Busca.ToUpper()) ||
                                            casa.endereco
                                                 .ToUpper()
                                                 .Contains(parametros.paginaParametros.Busca.ToUpper()) ||
                                            casa.valor.ToString()
                                                 .ToUpper()
                                                 .Contains(parametros.paginaParametros.Busca.ToUpper())
                                                  );

            return PaginaLista<Casa>.CreateAsync(query, parametros.paginaParametros.PaginaNumero, parametros.paginaParametros.PaginaTamanho);
        }

        #endregion Listar Casas

        #region Listar Dados Casa
        public async Task<ActionResult<OutListarDadosCasa>> ListarDadosCasa(InListarDadosCasa entrada)
        {
            OutListarDadosCasa retorno = new OutListarDadosCasa();

            var casa = await _context.Casas.FindAsync(entrada.idCasa);

            retorno.idCasa           = casa.idCasa;
            retorno.idCliente        = casa.idCliente;
            retorno.titulo           = casa.titulo;
            retorno.pequenaDescricao = casa.pequenaDescricao;
            retorno.endereco         = casa.endereco;
            retorno.cidade           = casa.cidade;
            retorno.tipo             = casa.tipo;
            retorno.descricao        = casa.descricao;
            retorno.valor            = casa.valor;
            retorno.oculto           = casa.oculto;

            return retorno;
        }

        #endregion Listar Dados Casa

        #region Atualizar Casa
        public async Task<OutAtualizarCasa> AtualizarCasa(InAtualizarCasa entrada)
        {
            OutAtualizarCasa retorno = new OutAtualizarCasa();

            var casaParaAtualizar = await _context.Casas.FindAsync(entrada.idCasa);

            if (casaParaAtualizar == null)
            {
                retorno.mensagem = "Não foi possivel localizar a casa pelo idCasa";
                return retorno;
            }

            _context.Entry(casaParaAtualizar).CurrentValues.SetValues(entrada); //seta o valor do model para o ESTABELECIMENTO
            _context.Casas.Update(casaParaAtualizar);

            await _context.SaveChangesAsync();
            retorno.mensagem = "Casa atualizado com sucesso!";

            return retorno;
        }

        #endregion Atualizar Casa

        #region Ocultar Casa
        public async Task<OutOcultarCasa> OcultarCasa(InOcultarCasa parametros)
        {
            OutOcultarCasa retorno = new OutOcultarCasa();
            var casa = _context.Casas
                               .Where(c => c.idCasa == parametros.idCasa)
                               .FirstOrDefault();

            if (casa.oculto != "S")
            {
                casa.oculto = "S";
                retorno.oculto = "Ocultado";
            }
            else
            {
                casa.oculto = "N";
                retorno.oculto = "Não está mais oculto!";
            }

            await _context.SaveChangesAsync();

            return retorno;
        }

        #endregion Ocultar Casa

        #region Excluir Casa
        public async Task<OutDeletarCasa> ExcluirCasa(InDeletarCasa entrada)
        {
            OutDeletarCasa retorno = new OutDeletarCasa();

            var deletarCasa = await _context.Casas.FindAsync(entrada.idCasa);

            if (deletarCasa == null)
            {
                retorno.mensagem = "Não foi possivel deletar a casa!";
                return retorno;
            }

            _context.Casas.Remove(deletarCasa);
            await _context.SaveChangesAsync();

            retorno.mensagem = "Casa deletada com sucesso!";
            return retorno;
        }

        #endregion Excluir Casa
    }
}