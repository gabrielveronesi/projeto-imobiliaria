$(function () {
    'use strict'

    $('[data-toggle="offcanvas"]').on('click', function () {
        $('.offcanvas-collapse').toggleClass('open')
    })

})

let getToken = localStorage.getItem("token")
let getIdCliente = localStorage.getItem("idCliente")
const auth = {
    headers: { Authorization: `Bearer ${getToken}` }
};


function adicionar() {

    let checkboxDestaque = document.getElementById('destaque');

    if (checkboxDestaque.checked) {
        checkboxDestaque = 'S'
    } else {
        checkboxDestaque = 'N'
    }

    let titulo = document.querySelector('#inputTitulo').value
    let pequenaDescricao = document.querySelector('#inputPequenaDescricao').value
    let endereco = document.querySelector('#inputEndereco').value
    let cidade = document.querySelector('#inputCidade').value
    let descricao = document.querySelector('#inputDescricao').value
    let finalidade = document.querySelector('#inputFinalidade').value

    //#region tratando o valor
    let valor = document.querySelector('#inputValor').value
    valor = valor.replace(',', '');
    valor = valor.replace('.', '');
    var valorConvertido = parseInt(valor);
    //#endregion tratando o valor

    let urlAdicionar = 'https://mobtec-server-teste.herokuapp.com/painel/cadastrar-casa'
    axios.post(urlAdicionar, {
        idCliente: getIdCliente,
        titulo: titulo,
        pequenaDescricao: pequenaDescricao,
        endereco: endereco,
        cidade: cidade,
        tipo: finalidade,
        descricao: descricao,
        valor: valorConvertido,
        destaque: checkboxDestaque

    }, auth)
        .then(response => {
            localStorage.setItem("idCasa", response.data.idCasa);
            window.location.href = "../imoveis/fotos.html";
        })
        .catch(error => {
            if (error.response.status == 401) {
                alert("Sua sessão expirou, faça o login novamente!")
                localStorage.removeItem("token");
                window.location.href = "../logar.html";
            } else {
                alert(error)
            }
        })
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