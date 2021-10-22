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
                idCliente = x.idCliente
                                                          ,
                nomeComercial = x.nomeComercial
                                                          ,
                nomeCliente = x.nomeCliente
                                                          ,
                logo = x.logo
                                                          ,
                whatsApp = x.whatsApp
                                                          ,
                telefone = x.telefone
                                                          ,
                email = x.email
                                                          ,
                endereco = x.endereco
                                                          ,
                facebook = x.facebook
                                                          ,
                instagram = x.instagram
                                                          ,
                linkedin = x.linkedin
                                                          ,
                youtube = x.youtube
                                                          ,
                twitter = x.twitter
                                                          ,
                urlCliente = x.urlCliente
                                                          ,
                snAtivo = x.snAtivo
                                                          ,
                banner01 = x.banner01
                                                          ,
                banner02 = x.banner02
                                                          ,
                banner03 = x.banner03
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
                                                     .Contains(parametros.paginaParametros.Busca.ToUpper())
                                                      );

                return PaginaLista<Casa>.CreateAsync(query, parametros.paginaParametros.PaginaNumero, parametros.paginaParametros.PaginaTamanho);

            }

            #endregion Listar Dados Cliente

        }
    }
}