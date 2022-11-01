$(function () {
    'use strict'

    $('[data-toggle="offcanvas"]').on('click', function () {
        $('.offcanvas-collapse').toggleClass('open')
    })
})

let getIdCasa = localStorage.getItem("idCasa")
let getToken = localStorage.getItem("token")
let getIdCliente = localStorage.getItem("idCliente")

const auth = {
    headers: { Authorization: `Bearer ${getToken}` }
};

function listarDadosCasa() {

    let urlListarDadosCasa = 'https://mobtec-server-teste.herokuapp.com/painel/listar-dados-casas'
    let body = {
        idCasa: getIdCasa,
    };

    axios.post(urlListarDadosCasa, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    }).then(response => {

        var dados = response.data;

        document.getElementById("atualizaReferencia").innerHTML = '<input class="form-control" type="text" placeholder="Referência:' + dados.idCasa + '" readonly>'
        document.getElementById("atualizaCasaTitulo").innerHTML = '<input type="email" value="' + dados.titulo + '" id="inputTitulo" class="form-control" placeholder="' + dados.titulo + '">';
        document.getElementById("atualizaPequenaDescricao").innerHTML = ' <textarea class="form-control" id="inputPequenaDescricao" rows="3" placeholder="' + dados.pequenaDescricao + '">' + dados.pequenaDescricao + '</textarea>'
        document.getElementById("atualizaEndereco").innerHTML = '<input type="email" value="' + dados.endereco + '" class="form-control" id="inputEndereco" placeholder="' + dados.endereco + '">'
        document.getElementById("atualizaCidade").innerHTML = '<input type="text" value="' + dados.cidade + '" class="form-control" id="inputCidade" placeholder="' + dados.cidade + '">'
        document.getElementById("atualizaDescricao").innerHTML = ' <textarea class="form-control" id="inputDescricao" rows="3" placeholder="' + dados.descricao + '">' + dados.descricao + '</textarea>'

        //valor
        document.getElementById("atualizaValor").innerHTML =
            '<div class="input-group mb-2">' +
            '<div class="input-group-prepend">' +
            '<div class="input-group-text">R$ </div>' +
            '</div>' +
            '<input type="text" class="dinheiro form-control"  value="' + formatarMoeda(dados.valor) + '" onkeyup="formatarMoeda()" id="inputValor" name="dinheiro" placeholder="' + dados.valor + '">'
        '</div>'

        //finalidade
        let opc1 = "Venda";
        let opc2 = "Locação";
        if (dados.finalidade == "Locação") {
            opc1 = "Locação";
            opc2 = "Venda";
        }
        document.getElementById("atualizaFinalidade").innerHTML =
            '<label for="inputFinalidade">Finalidade</label>' +
            '<select id="inputFinalidade" class="form-control">' +
            '<option>' + opc1 + '</option>' +
            '<option>' + opc2 + '</option>' +
            '</select>'

            console.log(dados.destaque)
        //destacado?
        if (dados.destaque == 'N') {
            document.getElementById("atualizaDestaque").innerHTML =
                '<input type="checkbox" class="form-check-input" id="destaque">' +
                '<label class="form-check-label" for="exampleCheck1">Imóvel em destaque</label>';
        } else {
            document.getElementById("atualizaDestaque").innerHTML =
                '<input type="checkbox" class="form-check-input" id="destaque" checked>' +
                '<label class="form-check-label" for="exampleCheck1">Imóvel em destaque</label>';
        }


        document.getElementById("botoes").innerHTML = '<button type="button" onclick=atualizar(' + getIdCasa + ') class="btn btn-success btn-lg btn-block"> Atualizar Imóvel </button>' +
            '<button type="button" onclick=atualizarFotos() class="btn btn-primary btn-lg btn-block"> Editar Fotos </button>' +
            '<button type="button" onclick=ocultar(' + getIdCasa + ') class="btn btn-warning btn-lg btn-block"> Ocultar Imóvel </button>' +
            '<button type="button" onclick=excluir(' + getIdCasa + ') class="btn btn-danger btn-lg btn-block"> Excluir Imóvel </button>';

    }).catch(function (error) {

        alert(error)

    }).finally(function () {
        // sempre executado
    });
}
listarDadosCasa();


function atualizar(casaId) {
    let titulo = document.querySelector('#inputTitulo').value
    let pequenaDescricao = document.querySelector('#inputPequenaDescricao').value
    let endereco = document.querySelector('#inputEndereco').value
    let cidade = document.querySelector('#inputCidade').value
    let descricao = document.querySelector('#inputDescricao').value
    let finalidade = document.querySelector('#inputFinalidade').value
    let checkboxDestaque = document.getElementById('destaque');

    if (checkboxDestaque.checked) {
        checkboxDestaque = 'S'
    } else {
        checkboxDestaque = 'N'
    }

    //#region tratando o valor
    let valor = document.querySelector('#inputValor').value
    valor = valor.replace(',', '');
    valor = valor.replace('.', '');
    var valorConvertido = parseInt(valor);
    //#endregion tratando o valor

    let urlAtualizarImovel = 'https://mobtec-server-teste.herokuapp.com/painel/atualizar-casa'
    let body = {
        idCasa: casaId,
        idCliente: getIdCliente,
        titulo: titulo,
        pequenaDescricao: pequenaDescricao,
        endereco: endereco,
        cidade: cidade,
        tipo: finalidade,
        descricao: descricao,
        valor: valorConvertido,
        oculto: "N",
        destaque: checkboxDestaque
    };

    axios.put(urlAtualizarImovel, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    })
        .catch(function (error) {
            alert(error);
        })
        .finally(function () {
            // sempre executado
        });

    alert("Imóvel atualizado!")
    window.location.href = "../imoveis/editar.html";

}

function ocultar(casaId) {
    let urlAtualizaOculto = 'https://mobtec-server-teste.herokuapp.com/painel/ocultar-casa'
    let body = {
        idCasa: casaId,
    };

    axios.post(urlAtualizaOculto, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    }).then(response => {

        alert("Imóvel Ocultado")
        window.location.href = "../imoveis/lista.html";

    }).catch(function (error) {

        alert(error)

    }).finally(function () {
        // sempre executado
    });
}

function excluir(casaId) {
    let urlExcluirCasa = 'https://mobtec-server-teste.herokuapp.com/painel/excluir-casa'
    let resultado = confirm("Essa ação é irreversível, deseja continuar?");
    let body = {
        idCasa: casaId
    };

    if (resultado == true) {

        axios.delete(urlExcluirCasa, {
            // headers: {
            //   Authorization: authorizationToken
            // },
            data: {
                idCasa: casaId
            }
        }).then(response => {

            alert("Imóvel excluido com sucesso!")
            window.location.href = "../imoveis/lista.html";

        }).catch(function (error) {

            alert(error)

        }).finally(function () {
            // sempre executado
        });;


        window.location.href = "../imoveis/lista.html";
    }
}

function atualizarFotos() {
    window.location.href = "../imoveis/fotos.html";
}

function sair() {
    localStorage.removeItem("token");
    window.location.href = "../logar.html";
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