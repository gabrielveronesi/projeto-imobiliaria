using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Models.Entity;
using server.Models.Inputs;
using server.Models.OutPuts;
using server.Repositories;

namespace server.Services
{
    public class PainelService
    {
        private readonly PainelRepository _painelRepository;

        public PainelService(PainelRepository painelRepository)
        {
            _painelRepository = painelRepository;
        }

        public async Task<OutLogarPainel> Logar(InLogarPainel entrada)
        {
            return await _painelRepository.Logar(entrada);
        }

        public async Task<OutCadastrarCasa> CadastrarCasa(InCadastrarCasa entrada)
        {

            Casa casa = new Casa();

            casa.idCliente = entrada.idCliente;
            casa.titulo = entrada.titulo;
            casa.pequenaDescricao = entrada.pequenaDescricao;
            casa.endereco = entrada.endereco;
            casa.cidade = entrada.cidade;
            casa.tipo = entrada.tipo;
            casa.descricao = entrada.descricao;
            casa.valor = entrada.valor;
            casa.oculto = "N";

            return await _painelRepository.CadastrarCasa(casa);
        }

        public async Task<ActionResult<List<OutListarCasasPainel>>> ListarCasas(InListarCasasPainel entrada)
        {
            List<OutListarCasasPainel> retorno = new List<OutListarCasasPainel>();
            
            var casas = await _painelRepository.ListarCasas(entrada);

            PaginaParametros auxPaginaParametros = new PaginaParametros() 
            {
                 PaginaNumero = 1,
                 PaginaTamanho = 99999,
                 Busca = null 
            }; 

            InListarCasasPainel auxInListarCasasPainel = new InListarCasasPainel() 
            {
                idCliente = entrada.idCliente,
                paginaParametros = auxPaginaParametros
            }; 

            var contadorCasa = await _painelRepository.ListarCasas(auxInListarCasasPainel);

            float contador = (int)Math.Ceiling(contadorCasa.Count / (double)entrada.paginaParametros.PaginaTamanho);
            
            foreach (var _casas in casas)
            {
                retorno.Add( new OutListarCasasPainel(){

                     idCasa           = _casas.idCasa
                    ,idCliente        = _casas.idCliente
                    ,titulo           = _casas.titulo
                    ,pequenaDescricao = _casas.pequenaDescricao
                    ,endereco         = _casas.endereco
                    ,cidade           = _casas.cidade
                    ,tipo             = _casas.tipo
                    ,descricao        = _casas.descricao
                    ,valor            = _casas.valor
                    ,oculto           = _casas.oculto
                    ,totalPaginas     = contador

                });
            }

            return retorno;
        }

        public async Task<ActionResult<OutListarDadosCasa>> ListarDadosCasa(InListarDadosCasa entrada)
        {
            return await _painelRepository.ListarDadosCasa(entrada);
        }

        public async Task<OutAtualizarCasa> AtualizarCasa(InAtualizarCasa entrada)
        {
            return await _painelRepository.AtualizarCasa(entrada);
        }

        public async Task<OutOcultarCasa> OcultarCasa(InOcultarCasa entrada)
        {
            return await _painelRepository.OcultarCasa(entrada);
        }

        public async Task<OutDeletarCasa> ExcluirCasa(InDeletarCasa entrada)
        {
            return await _painelRepository.ExcluirCasa(entrada);
        }
    }
}