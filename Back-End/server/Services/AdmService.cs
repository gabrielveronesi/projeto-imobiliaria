using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Helpers;
using server.Models.Entity;
using server.Models.Inputs;
using server.Models.OutPuts;
using server.Repositories;

namespace server.Services
{
    public class AdmService
    {
        private readonly AdmRepository _admRepository;

        public AdmService(AdmRepository admRepository)
        {
            _admRepository = admRepository;
        }
        public OutLogarAdm Logar(InLogarAdm entrada)
        {
            OutLogarAdm retorno = new OutLogarAdm();

            if (entrada.usuario == "adm" &&
                entrada.senha == "adm")
            {
                retorno.sucesso = true;
                retorno.mensagem = "Login efetuado com sucesso!";

                return retorno;
            }

            retorno.sucesso = false;
            retorno.mensagem = "Usuario ou senha inválido!";

            return retorno;
        }

        public async Task<OutCadastroCliente> CadastrarCliente(InCadastroCliente entrada)
        {
            Cliente novoCliente = new Cliente() { };

            novoCliente.nomeComercial = entrada.nomeComercial;
            novoCliente.nomeCliente   = entrada.nomeCliente;
            novoCliente.logo          = entrada.logo;
            novoCliente.whatsApp      = entrada.whatsApp;
            novoCliente.telefone      = entrada.telefone;
            novoCliente.email         = entrada.email;
            novoCliente.endereco      = entrada.endereco;
            novoCliente.facebook      = entrada.facebook;
            novoCliente.instagram     = entrada.instagram;
            novoCliente.linkedin      = entrada.linkedin;
            novoCliente.youtube       = entrada.youtube;
            novoCliente.twitter       = entrada.twitter;
            novoCliente.snAtivo       = "S"; //Sempre vai cadastrar como cliente Ativo
            novoCliente.urlCliente    = GerarUrl.Gerar(true, entrada.nomeComercial); //TODO: Fazer validação se o nome já existe

            novoCliente.usuario = entrada.email;
            novoCliente.senha   = GerarSenha.NovaSenha();
            
            return await _admRepository.CadastrarCliente(novoCliente);

        }

        public List<OutListarClientes> ListarClientes()
        {
            return _admRepository.ListarClientes();
        }

        public async Task<OutAtualizarCliente> AtualizarCliente(InAtualizarCliente entrada)
        {
            return await _admRepository.AtualizarCliente(entrada);
        }

        public OutListarDadosClienteAdm ListarDadosCliente(InListarDadosCliente entrada)
        {
            return _admRepository.ListarDadosCliente(entrada);
        }
    }
}