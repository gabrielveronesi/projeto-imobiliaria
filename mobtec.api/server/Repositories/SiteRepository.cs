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

namespace server.Repositories
{
    public class SiteRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public SiteRepository(DataContext context,
                              IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #region Listar configurações do cliente passando a url
        public OutListarDadosClienteSite ListarConfiguracoes(string urlCliente)
        {
            var resultado = _context.Clientes.Select(x => new OutListarDadosClienteSite()
            {
                idCliente = x.idCliente,
                nomeComercial = x.nomeComercial,
                nomeCliente = x.nomeCliente,
                logo = x.logo,
                whatsApp = x.whatsApp,
                telefone = x.telefone,
                email = x.email,
                endereco = x.endereco,
                facebook = x.facebook,
                instagram = x.instagram,
                linkedin = x.linkedin,
                youtube = x.youtube,
                twitter = x.twitter,
                urlCliente = x.urlCliente,
                snAtivo = x.snAtivo,
                banner01 = x.banner01,
                banner02 = x.banner02,
                banner03 = x.banner03,
                bannerSobre = x.bannerSobre,
                descricaoSobre = x.descricaoSobre
            }).Where(x => x.urlCliente == urlCliente);

            return resultado.FirstOrDefault();

        }
        #endregion Listar Dados Cliente

        #region Listar casas do Cliente passando a url
        public Task<PaginaLista<Casa>> ListarCasas(InListarCasasSite parametros)
        {
            //Buscando o idCliente
            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@UrlCliente", parametros.urlCliente);

                con.Open();

                var sql = @"SELECT idCliente = Clientes.idCliente
                            FROM Casas
                            INNER JOIN Clientes
                            ON Clientes.idCliente = Casas.idCliente
                            WHERE Clientes.urlCliente = @UrlCliente
                              AND Casas.oculto = 'N'";

                var idCliente = con.QueryFirstOrDefault<int>(sql: sql,
                                                             param: parametros,
                                                             commandType: CommandType.Text);

                IQueryable<Casa> query = _context.Casas;

                query = query.AsNoTracking().OrderBy(a => a.idCasa)
                                            .Where(a => a.idCliente == idCliente);

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
                                                     .Contains(parametros.paginaParametros.Busca.ToUpper())||
                                                casa.tipo.ToString()
                                                     .ToUpper()
                                                     .Contains(parametros.paginaParametros.Busca.ToUpper()));

                return PaginaLista<Casa>.CreateAsync(query, parametros.paginaParametros.PaginaNumero, parametros.paginaParametros.PaginaTamanho);

            }
        }
        #endregion Listar Dados Cliente

        #region Listar casas do Cliente passando a url
        public async Task<List<OutSiteListarCasasFiltro>> ListarCasasFiltros(InSiteListarCasasFiltro parametros)
        {

            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                List<OutSiteListarCasasFiltro> retorno = new List<OutSiteListarCasasFiltro>();

                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@UrlCliente", parametros.urlCliente);
                _parametros.Add("@finalidade", parametros.finalidade);
                _parametros.Add("@cidade", parametros.cidade);
                _parametros.Add("@endereco", parametros.endereco);

                con.Open();

                var sql = @"SELECT idCasa          
                                  ,titulo          
                                  ,pequenaDescricao
                                  ,valor           
                                  ,oculto   
                            	  ,tipo
                            FROM Casas
                            INNER JOIN Clientes
                            ON Clientes.idCliente = Casas.idCliente AND
                               Clientes.urlCliente = @UrlCliente
                            WHERE Casas.tipo = @finalidade
                              AND Casas.cidade    LIKE CONCAT('%', @cidade, '%')
                              AND Casas.endereco  LIKE CONCAT('%', @endereco, '%')";

                var resultado = await con.QueryAsync(sql: sql,
                                                     param: _parametros,
                                                     commandType: CommandType.Text);

                foreach (var _resultado in resultado)
                {
                    retorno.Add(new OutSiteListarCasasFiltro()
                    {
                        idCasa           = _resultado.idCasa,
                        titulo           = _resultado.titulo,
                        pequenaDescricao = _resultado.pequenaDescricao,
                        valor            = _resultado.valor,
                        oculto           = _resultado.oculto
                    });
                }
                
                return retorno;

            }
        }
        #endregion Listar Dados Cliente

        #region Listar fotos da casa
        public async Task<List<OutSiteListarCasasDestaque>> ListarCasasDestaque(string urlCliente)
        {
            List<OutSiteListarCasasDestaque> retorno = new List<OutSiteListarCasasDestaque>();

            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@urlCliente", urlCliente);

                con.Open();

                var sql = @"SELECT idCasa          
                                  ,titulo          
                                  ,pequenaDescricao
                                  ,valor   
                            FROM Casas
                            INNER JOIN Clientes
                            ON Clientes.idCliente = Casas.idCliente
                            WHERE Clientes.urlCliente = @urlCliente
                              AND Casas.destaque = 'S'
                              AND Casas.oculto = 'N'";

                var resultado = await con.QueryAsync(sql: sql,
                                                     param: _parametros,
                                                     commandType: CommandType.Text);

                foreach (var _resultado in resultado)
                {
                    retorno.Add(new OutSiteListarCasasDestaque()
                    {
                        idCasa           = _resultado.idCasa,
                        titulo           = _resultado.titulo,
                        pequenaDescricao = _resultado.pequenaDescricao,
                        valor            = _resultado.valor
                    });
                }

                return retorno;
            }

        }
        #endregion Listar fotos da casa

        #region Listar fotos da casa
        public async Task<List<OutSiteListarFotosCasa>> ListarFotosCasas(InSiteListarFotosCasa parametros)
        {
            
            List<OutSiteListarFotosCasa> retorno = new List<OutSiteListarFotosCasa>();

            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@idCasa", parametros.idCasa);
                _parametros.Add("@urlCliente", parametros.urlCliente);

                con.Open();

                var sql = @"SELECT urlFoto
                            FROM Fotos
                            INNER JOIN Clientes
                            ON Clientes.idCliente = Fotos.idCliente
                            WHERE Fotos.idCasa = @idCasa
                              AND Clientes.urlCliente = @urlCliente";

                var resultado = await con.QueryAsync(sql: sql,
                                                     param: _parametros,
                                                     commandType: CommandType.Text);

                foreach (var _resultado in resultado)
                {
                    retorno.Add(new OutSiteListarFotosCasa()
                    {
                        urlFoto = _resultado.urlFoto
                    });
                }

                return retorno;
            }

        }
        #endregion Listar fotos da casa

        #region Listar configurações casa
        public async Task<OutSiteConfiguracoesCasa> ListarConfiguracoesCasa(InSiteConfiguracoesCasa parametros)
        {
            OutSiteConfiguracoesCasa retorno = new OutSiteConfiguracoesCasa();

            using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
            {
                DynamicParameters _parametros = new DynamicParameters();
                _parametros.Add("@idCasa", parametros.idCasa);
                _parametros.Add("@urlCliente", parametros.urlCliente);

                con.Open();

                var sql = @"SELECT Casas.idCasa
                                  ,Casas.titulo          
                                  ,Casas.pequenaDescricao
                                  ,Casas.endereco        
                                  ,Casas.cidade          
                                  ,Casas.tipo            
                                  ,Casas.descricao       
                                  ,Casas.valor           
                                  ,Casas.oculto     
                            FROM Casas
                            INNER JOIN Clientes
                            ON Clientes.idCliente = Casas.idCliente
                            WHERE Casas.idCasa = @idCasa
                              AND Clientes.urlCliente = @urlCliente";

                retorno = await con.QueryFirstAsync<OutSiteConfiguracoesCasa>(sql: sql,
                                                                               param: _parametros,
                                                                               commandType: CommandType.Text);

                 return retorno;
            }
        }
        #endregion Listar configurações casa
    }
}