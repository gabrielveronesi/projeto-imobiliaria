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
//     public class CasaRepository
//     {
//         private readonly DataContext _context;
//         public CasaRepository(DataContext context)
//         {
//             _context = context;
//         }
//         public async Task<Casa> AdicionarCasa(Casa entrada)
//         {
//             await _context.Casas.AddAsync(entrada);
//             await _context.SaveChangesAsync();
//             return entrada;
//         }

//         public async Task<PaginaLista<Casa>> ListarCasas(string usuarioLogado, PaginaParametros paginaParametros)
//         {
//             IQueryable<Casa> query = _context.Casas;
//             query = query.AsNoTracking().OrderBy(a => a.CasaId).Where(a => a.ClienteId == usuarioLogado).IgnoreAutoIncludes<Casa>();
            
//             if (!string.IsNullOrEmpty(paginaParametros.Busca))
//                 query = query.Where(casa => casa.Referencia.ToString()
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper()) ||
//                                              casa.Titulo
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper()) ||
//                                              casa.Endereco
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper()) ||
//                                              casa.Descricao
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper())
//                                                   );

//             if (query.Count() <= 0)
//             {
//                 return null;
//             }
            
//             return await PaginaLista<Casa>.CreateAsync(query, paginaParametros.PaginaNumero, paginaParametros.PaginaTamanho);
//         }

//         public async Task<ActionResult<Casa>> ListarCasa(int CasaId)
//         {
//             var casa = await _context.Casas.FindAsync(CasaId);

//             if (casa == null)
//             {
//                 return null;
//             }

//             return casa;
//         }

//         public async Task<bool> DeletarCasa(int CasaId)
//         {
//             var deletarCasa = await _context.Casas.FindAsync(CasaId);

//             if (deletarCasa == null)
//             {
//                 return false;
//             }

//             var remover = _context.Casas.Remove(deletarCasa);
//             await _context.SaveChangesAsync();
//             return true;
//         }

//         public async Task<bool> AtualizarCasa(int CasaId, InCasa casa)
//         {
//             var atualizaCasa = await _context.Casas.FindAsync(CasaId);

//             if (atualizaCasa == null)
//             {
//                 return false;
//             }

//             _context.Entry(atualizaCasa).CurrentValues.SetValues(casa); //seta o valor do model para o ESTABELECIMENTO
//             _context.Casas.Update(atualizaCasa);

//             await _context.SaveChangesAsync();

//             return true;
//         }

//         public async Task<bool> AtualizarOculto(int CasaId, string Oculto)
//         {
//             var atualizaCasa = await _context.Casas.FindAsync(CasaId);

//             if (atualizaCasa == null)
//             {
//                 return false;
//             }

//             atualizaCasa.Oculto = Oculto;

//             _context.Casas.Update(atualizaCasa);

//             await _context.SaveChangesAsync();

//             return true;
//         }
//         public async Task<PaginaLista<Casa>> ListarCasasUrl(string usuarioLogado, string UrlCliente, PaginaParametros paginaParametros)
//         {
//             var clienteId = "";
//             using (var con = new SqlConnection(DataContext.ObterStringDeConexao()))
//             {
//                 DynamicParameters parametros = new DynamicParameters();
//                 parametros.Add("@Url", UrlCliente);

//                 con.Open();

//                 string sql = @"SELECT Id
//                                FROM AspNetUsers
//                                WHERE Url = @Url";

//                 var retorno = await con.QueryFirstOrDefaultAsync<string>(sql: sql,
//                                                                          param: parametros,
//                                                                          commandType: CommandType.Text);
                
//                 clienteId = retorno;
//             }

//             IQueryable<Casa> query = _context.Casas;

//             query = query.AsNoTracking()
//                          .OrderBy(a => a.CasaId)
//                          .Where(a => a.Oculto == "N")
//                          .Where(a => a.ClienteId == clienteId)
//                          .IgnoreAutoIncludes<Casa>();
            
//             if (!string.IsNullOrEmpty(paginaParametros.Busca))
//                 query = query.Where(casa =>  casa.Oculto == "N" &&
//                                              casa.Referencia.ToString()
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper()) ||
//                                              casa.Titulo
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper()) ||
//                                              casa.Endereco
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper()) ||
//                                              casa.Descricao
//                                                   .ToUpper()
//                                                   .Contains(paginaParametros.Busca.ToUpper())
//                                                   );

//             if (query.Count() <= 0)
//             {
//                 return null;
//             }

            
            

//             return await PaginaLista<Casa>.CreateAsync(query, paginaParametros.PaginaNumero, paginaParametros.PaginaTamanho);
//         }

//         public async Task<ActionResult<Casa>> ListarCasaApresentacao(int CasaId)
//         {
//             var casa = await _context.Casas.FindAsync(CasaId);

//             if (casa == null)
//             {
//                 return null;
//             }

//             return casa;
//         }
//     }
// }


