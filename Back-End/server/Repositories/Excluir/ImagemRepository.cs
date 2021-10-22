// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using server.Data;
// using server.Helpers;
// using server.Models;
// using server.Models.Inputs;

// namespace server.Repositories
// {
//     public class ImagemRepository
//     {
//         private readonly DataContext _context;
//         public ImagemRepository(DataContext context)
//         {
//             _context = context;
//         }
//         public async Task<bool> AdicionarImagem(Imagem entrada)
//         {
//             var img = new Imagem()
//             {
//                 ImagemId  = entrada.ImagemId,
//                 AddImagem = entrada.AddImagem,
//                 CasaId    = entrada.CasaId
//             };

//             try
//             {
//                 await _context.Imagens.AddAsync(img);
//                 await _context.SaveChangesAsync();
//                 return true;
//             }
//             catch
//             {
//                 return false;
//             }
//         }

//         public async Task<List<Imagem>> ListarImagens(int casaId)
//         {
//             var query = await _context.Imagens.Where(u => u.CasaId == casaId)
//                                               .ToListAsync();

//             if (query.Count() <= 0)
//             {
//                 return null;
//             }

//             return query;
//         }

//         public async Task<Imagem> ListarImagemCapa(int casaId)
//         {
//             var query = await _context.Imagens.Where(u => u.CasaId == casaId)
//                                               .FirstOrDefaultAsync();

//             if (query == null)
//             {
//                 return null;
//             }

//             return query;
//         }

//         public async Task<bool> DeletarImagem(string imagemId)
//         {
//             var deletarImagem = await _context.Imagens.FindAsync(imagemId);

//             if (deletarImagem == null)
//             {
//                 return false;
//             }

//             var remover = _context.Imagens.Remove(deletarImagem);
//             await _context.SaveChangesAsync();
//             return true;
//         }
//     }
// }