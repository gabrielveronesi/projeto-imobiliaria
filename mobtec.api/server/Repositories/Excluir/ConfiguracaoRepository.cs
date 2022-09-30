// using System.Collections.Generic;
// using System.Data;
// using System.Data.SqlClient;
// using System.Linq;
// using System.Threading.Tasks;
// using Dapper;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using server.Data;
// using server.Helpers;
// using server.Models;
// using server.Models.Inputs;

// namespace server.Repositories
// {
//     public class ConfiguracaoRepository
//     {
//         private readonly DataContext _context;
//         public ConfiguracaoRepository(DataContext context)
//         {
//             _context = context;
//         }
//         public async Task<Casa> AdicionarCasa(Casa entrada)
//         {
//             await _context.Casas.AddAsync(entrada);
//             await _context.SaveChangesAsync();
//             return entrada;
//         }

//         public async Task<string> AdicionarUrl(string urlCliente, string emailCliente)
//         {
//             using (var con = new SqlConnection(DataContext.ObterStringDeConexao()))
//             {
//                 DynamicParameters parametros = new DynamicParameters();
//                 parametros.Add("@UrlCliente", urlCliente);
//                 parametros.Add("@EmailCliente", emailCliente);

//                 con.Open();

//                 string sql = @"UPDATE AspNetUsers
//                               SET Url = @UrlCliente
//                               WHERE Email = @EmailCliente";

//                 await con.QueryAsync<string>(sql: sql,
//                                              param: parametros,
//                                              commandType: CommandType.Text);


//                 return urlCliente;
//             }
//         }

//         public async Task<bool> VerificarUrlExistente(string urlCliente)
//         {
//             using (var con = new SqlConnection(DataContext.ObterStringDeConexao()))
//             {
//                 DynamicParameters parametros = new DynamicParameters();
//                 parametros.Add("@UrlCliente", urlCliente);

//                 con.Open();

//                 string sql = @"SELECT *
//                                FROM AspNetUsers
//                                WHERE Url = @UrlCliente";

//                 var retorno = await con.QueryAsync<string>(sql: sql,
//                                                            param: parametros,
//                                                            commandType: CommandType.Text);


//                 if (retorno.Count() > 0)
//                     return false;

//                 return true;
//             }
//         }

//         public async Task<Configuracao> AdicionarConfiguracoes(Configuracao configuracao, string emailCliente)
//         {
//             using (var con = new SqlConnection(DataContext.ObterStringDeConexao()))
//             {
//                 DynamicParameters parametros = new DynamicParameters();
//                 parametros.Add("@Email", emailCliente);

//                 con.Open();

//                 string sql = @"SELECT Id
//                                FROM AspNetUsers
//                                WHERE Email = @Email";

//                 var retorno = await con.QueryFirstOrDefaultAsync<string>(sql: sql,
//                                                                          param: parametros,
//                                                                          commandType: CommandType.Text);

//                 configuracao.ClienteId = retorno;

//                 parametros.Add("@ClienteId", retorno);

//                 string verificaExistenteSql = @"SELECT ConfiguracaoId
//                                                 FROM Configuracoes
//                                                 WHERE ClienteId = @ClienteId";

//                 var verificaExistente = await con.QueryFirstOrDefaultAsync<int>(sql: verificaExistenteSql,
//                                                                                    param: parametros,
//                                                                                    commandType: CommandType.Text);


//                 if (verificaExistente > 0)
//                 {
//                     configuracao.ConfiguracaoId = verificaExistente;
//                     _context.Configuracoes.Update(configuracao);
//                     await _context.SaveChangesAsync();
//                     return configuracao;
//                 }
//                 else
//                 {
//                     await _context.Configuracoes.AddAsync(configuracao);
//                     await _context.SaveChangesAsync();
//                     return configuracao;
//                 }
//             }
//         }

//         public async Task<ActionResult<Configuracao>> ListarConfiguracao(string urlCliente)
//         {
//             using (var con = new SqlConnection(DataContext.ObterStringDeConexao()))
//             {
//                 DynamicParameters parametros = new DynamicParameters();
//                 parametros.Add("@Url", urlCliente);

//                 con.Open();

//                 string sql = @"SELECT Id
//                                FROM AspNetUsers
//                                WHERE Url = @Url";

//                 var retorno = await con.QueryFirstOrDefaultAsync<string>(sql: sql,
//                                                                          param: parametros,
//                                                                          commandType: CommandType.Text);
                
//                 parametros.Add("@ClienteId", retorno);

//                 string ConfiguracaoIdSql = @"SELECT ConfiguracaoId
//                                              FROM Configuracoes
//                                              WHERE ClienteId = @ClienteId";

//                 var configId = await con.QueryFirstOrDefaultAsync<int>(sql: ConfiguracaoIdSql,
//                                                                        param: parametros,
//                                                                        commandType: CommandType.Text);

//                 var resultado = await _context.Configuracoes.FindAsync(configId);

//                 if (resultado == null)
//                 {
//                     return null;
//                 }

//                 return resultado;
//             }
//         }

//         public async Task<ActionResult<Configuracao>> ListarConfiguracaoAuth(string userAuthId)
//         {
//             using (var con = new SqlConnection(DataContext.ObterStringDeConexao()))
//             {
//                 DynamicParameters parametros = new DynamicParameters();
//                 parametros.Add("@ClienteId", userAuthId);

//                 string ConfiguracaoIdSql = @"SELECT ConfiguracaoId
//                                              FROM Configuracoes
//                                              WHERE ClienteId = @ClienteId";

//                 var configId = await con.QueryFirstOrDefaultAsync<int>(sql: ConfiguracaoIdSql,
//                                                                        param: parametros,
//                                                                        commandType: CommandType.Text);

//                 var resultado = await _context.Configuracoes.FindAsync(configId);

//                 if (resultado == null)
//                 {
//                     return null;
//                 }

//                 return resultado;
//             }
//         }
//     }
// }


