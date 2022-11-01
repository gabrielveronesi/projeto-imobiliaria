$(function () {
    'use strict'

    $('[data-toggle="offcanvas"]').on('click', function () {
        $('.offcanvas-collapse').toggleClass('open')
    })
})

let urlLogin = 'https://mobtec-server-teste.herokuapp.com/cliente-autenticado/login'
let getToken = localStorage.getItem("token")
let getidCliente = localStorage.getItem("idCliente")
let getBusca = localStorage.getItem("busca")
let getPaginaNumero = localStorage.getItem("paginaNumero")

const auth = {
    headers: { Authorization: `Bearer ${getToken}` }
};

if (getPaginaNumero == null)
{
    getPaginaNumero = 1
}

let urlListaCasas = 'https://mobtec-server-teste.herokuapp.com/painel/listar-casas'
axios.post(urlListaCasas, {

    //Body
    idCliente: getidCliente,
    paginaParametros: {
        paginaNumero: getPaginaNumero,
        paginaTamanho: 10,
        busca: getBusca
    }

})
    .then(response => {

        //#region Listando as casas
        let tableText = "";
        let botaoPesquisar = "";
        let paginacao = "";
        let totalPaginas = 0;

        let json = response.data;
        json.forEach((casa) => {

            let oculto = '<a class="btn btn-primary btn-sm" onclick="editar(' + casa.idCasa + ')" style="float:none!important;display:inline;color:lavenderblush;" value="' + casa.casaId + '">Editar</a>';
            if (casa.oculto == "S") {
                oculto = '<a class="btn btn-dark btn-sm" onclick="ativar(' + casa.idCasa + ')" style="float:none!important;display:inline;color:lavenderblush;" value="' + casa.casaId + '">Ativar</a>';

            }

            tableText +=
                '<div class="media text-muted pt-3" id="tabelaListaImoveis">' +
                '<div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">' +
                '<div class="d-flex justify-content-between align-items-center w-100">' +
                '<strong class="text-gray-dark">Referência: ' + casa.idCasa + '</strong>' +
                oculto +
                '</div>' +
                '<span class="d-block">' + casa.titulo + '</span>' +
                '<span class="d-block">R$' + formatarMoeda(casa.valor) + '</span>' +
                '</div>' +
                '</div>'

            totalPaginas = casa.totalPaginas;
        })

        if (getBusca == null) {
            getBusca = '';
        }

        botaoPesquisar += '<form class="form-inline my-lg-3">' +
            '<input class="form-control mr-sm-2" id="inputPesquisar" type="search" placeholder="' + getBusca + '" aria-label="Pesquisar">' +
            '<button class="btn btn-outline-success my-lg-2 my-sm-2" onclick="pesquisar()">Pesquisar</button>' +
            '<button class="btn btn-outline-warning my-lg-2 my-sm-2" onclick="limparPesquisar()" style="margin:15px;">Limpar Busca</button>' +
            '</form>';

        var paginacaotxt = '';
        for (let index = 1; index <= totalPaginas; index++) {

            paginacaotxt = paginacaotxt + '<button class="btn btn-outline-warning my-lg-2 my-sm-2" style="margin: 0;" onclick="addPagina('+index+')" style="margin:15px;">' + index + '</button>'

        }


        paginacao += paginacaotxt 

        document.getElementById("TabelaListaImoveis").innerHTML = tableText;
        document.getElementById("BotaoPesquisar").innerHTML = botaoPesquisar;

        if (getBusca == null || getBusca == '')
        {
            document.getElementById("Paginacao").innerHTML = paginacao;
        }
        
        //#endregion Listando as casas

    })
    .catch(error => {
        alert(error)
    })

function addPagina(pag) {

    localStorage.setItem("paginaNumero", pag)
    window.location.href = "../imoveis/lista.html";
}

function sair() {
    localStorage.removeItem("token");
    window.location.href = "../logar.html";
}

function editar(idCasa) {
    localStorage.setItem("idCasa", idCasa)

    window.location.href = "../imoveis/editar.html";
}

function pesquisar() {
    let busca = document.querySelector('#inputPesquisar').value
    localStorage.setItem("paginaNumero", 1)
    localStorage.setItem("busca", busca)

    window.location.href = "../imoveis/lista.html";

}

function limparPesquisar() {
    localStorage.removeItem("busca");

    window.location.href = "../imoveis/lista.html";

}

function ativar(casaId) {

    let urlAtualizaOculto = 'https://mobtec-server-teste.herokuapp.com/painel/ocultar-casa'
    let body = {
        idCasa: casaId,
    };

    axios.post(urlAtualizaOculto, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    }).then(response => {

        alert("Imóvel Ativado!")
        window.location.href = "../imoveis/lista.html";

    }).catch(function (error) {

        alert(error)

    }).finally(function () {
        // sempre executado
    });
}

function mudarPagina(numeroPagina) {
    localStorage.setItem("paginaNumeroPainel", numeroPagina);
    location.reload();
}

function formatarMoeda(input) {

    if (input == null) {
        var elemento = document.getElementById('inputValor');
        var valor = elemento.value;
    }
    else {
        var elemento = input;
        var valor = input;
    }

    valor = valor + '';
    valor = parseInt(valor.replace(/[\D]+/g, ''));
    valor = valor + '';
    valor = valor.replace(/([0-9]{2})$/g, ",$1");

    if (valor.length > 6) {
        valor = valor.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
    }

    elemento.value = valor;
    if (valor == 'NaN') elemento.value = '';

    return valor;
}