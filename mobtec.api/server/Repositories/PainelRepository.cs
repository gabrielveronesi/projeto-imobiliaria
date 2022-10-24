using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private readonly AuthenticatedUser _userAuth;
        public PainelRepository(DataContext context,
                                IConfiguration configuration,
                                AuthenticatedUser userAuth)
        {
            _context = context;
            _configuration = configuration;
            _userAuth = userAuth;
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

            retorno.idCasa = casa.idCasa;
            retorno.idCliente = casa.idCliente;
            retorno.titulo = casa.titulo;
            retorno.pequenaDescricao = casa.pequenaDescricao;
            retorno.endereco = casa.endereco;
            retorno.cidade = casa.cidade;
            retorno.tipo = casa.tipo;
            retorno.descricao = casa.descricao;
            retorno.valor = casa.valor;
            retorno.oculto = casa.oculto;
            retorno.destaque = casa.destaque;

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

        #region Listar Configuracoes
        public async Task<OutListarDadosClientePainel> ListarConfiguracoes(InListarDadosClientePainel entrada)
        {
            OutListarDadosClientePainel retorno = new OutListarDadosClientePainel();

            var DadosCliente = await _context.Clientes.FindAsync(entrada.idCliente);

            retorno.nomeComercial = DadosCliente.nomeComercial;
            retorno.nomeCliente = DadosCliente.nomeCliente;
            retorno.logo = DadosCliente.logo;
            retorno.whatsApp = DadosCliente.whatsApp;
            retorno.telefone = DadosCliente.telefone;
            retorno.email = DadosCliente.email;
            retorno.endereco = DadosCliente.endereco;
            retorno.facebook = DadosCliente.facebook;
            retorno.instagram = DadosCliente.instagram;
            retorno.linkedin = DadosCliente.linkedin;
            retorno.youtube = DadosCliente.youtube;
            retorno.twitter = DadosCliente.twitter;
            retorno.banner01 = DadosCliente.banner01;
            retorno.banner02 = DadosCliente.banner02;
            retorno.banner03 = DadosCliente.banner03;

            return retorno;
        }

        #endregion Listar Configuracoes

        #region Cadastrar Foto
        public async Task<OutCadastrarFoto> CadastrarFoto(InCadastrarFoto parametros, string urlFoto)
        {
            OutCadastrarFoto retorno = new OutCadastrarFoto();

            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@idCasa", parametros.idCasa);
                _parametros.Add("@idCliente", parametros.idCliente);
                _parametros.Add("@urlFoto", urlFoto);

                con.Open();

                var sql = @"INSERT INTO Fotos 
                            VALUES(@idCasa
                                  ,@idCliente
                                  ,@urlFoto)
                            
                            SELECT @@IDENTITY"; //Retorno do id

                retorno.idFoto = await con.QueryFirstAsync<int>(sql: sql,
                                                                param: _parametros,
                                                                commandType: CommandType.Text);
                return retorno;
            }
        }

        #endregion Cadastrar Foto

        #region Listar fotos
        public async Task<List<OutListarFotos>> ListarFotos(InListarFotos parametros)
        {
            List<OutListarFotos> retorno = new List<OutListarFotos>();

            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@idCasa", parametros.idCasa);
                _parametros.Add("@idCliente", parametros.idCliente);

                con.Open();

                var sql = @"SELECT urlFoto
                                  ,idFoto
                            FROM Fotos
                            WHERE idCliente = @idCliente
                              AND idCasa = @idCasa";

                var resultado = await con.QueryAsync(sql: sql,
                                                     param: _parametros,
                                                     commandType: CommandType.Text);

                foreach (var _resultado in resultado)
                {
                    retorno.Add(new OutListarFotos()
                    {
                        urlFoto = _resultado.urlFoto,
                        idFoto = _resultado.idFoto
                    });
                }

                return retorno;
            }
        }
        #endregion Listar Fotos

        #region Excluir Foto
        public async Task<OutDeletarFoto> ExcluirFoto(int idFoto)
        {
            OutDeletarFoto retorno = new OutDeletarFoto();

            var deletarFoto = await _context.Fotos.FindAsync(idFoto);

            if (deletarFoto == null)
            {
                retorno.mensagem = "Não foi possivel deletar a foto!";
                return retorno;
            }

            _context.Fotos.Remove(deletarFoto);
            await _context.SaveChangesAsync();

            retorno.mensagem = "Foto deletada com sucesso!";
            return retorno;
        }
        #endregion Excluir Foto


        #region Atualizar Configuracoes Geral
        public async Task<OutPainelAtualizarConfiguracoesGeral> AtualizarConfiguracoesGeral(InPainelAtualizarConfiguracoesGeral entrada)
        {
            OutPainelAtualizarConfiguracoesGeral retorno = new OutPainelAtualizarConfiguracoesGeral();

            try
            {
                using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
                {
                    DynamicParameters _parametros = new DynamicParameters();
                    _parametros.Add("@idCliente", entrada.idCliente);
                    _parametros.Add("@nomeComercial", entrada.nomeComercial);
                    _parametros.Add("@whatsApp", entrada.whatsApp);
                    _parametros.Add("@telefone", entrada.telefone);
                    _parametros.Add("@email", entrada.email);
                    _parametros.Add("@endereco", entrada.endereco);
                    _parametros.Add("@facebook", entrada.facebook);
                    _parametros.Add("@instagram", entrada.instagram);
                    _parametros.Add("@linkedin", entrada.linkedin);
                    _parametros.Add("@youtube", entrada.youtube);
                    _parametros.Add("@twitter", entrada.twitter);

                    con.Open();

                    var sql = @"UPDATE Clientes
                                SET nomeComercial = @nomeComercial      
                                   ,whatsApp      = @whatsApp            
                                   ,telefone      = @telefone            
                                   ,email         = @email               
                                   ,endereco      = @endereco            
                                   ,facebook      = @facebook            
                                   ,instagram     = @instagram          
                                   ,linkedin      = @linkedin            
                                   ,youtube       = @youtube            
                                   ,twitter		  = @twitter
                                WHERE idCliente = @idCliente";

                    await con.ExecuteAsync(sql: sql,
                                           param: _parametros,
                                           commandType: CommandType.Text);


                    retorno.mensagem = "Configurações atualizadas com sucesso!";
                    return retorno;
                }
            }
            catch (System.Exception)
            {
                retorno.mensagem = "Não foi possivel atualizar as informações!";
                return retorno;
            }
        }
        #endregion Atualizar Configuracoes Geral

    }
}