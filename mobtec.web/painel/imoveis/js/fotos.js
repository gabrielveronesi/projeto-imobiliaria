$(function () {
    'use strict'

    $('[data-toggle="offcanvas"]').on('click', function () {
        $('.offcanvas-collapse').toggleClass('open')
    })

    listarImagens();
})

let token = localStorage.getItem("token")
let idCasa = localStorage.getItem("idCasa")
let idCliente = localStorage.getItem("idCliente")
let html = "";

const auth = {
    headers: { Authorization: `Bearer ${token}` }
};

var loaderFile = function (event) {
    var reader = new FileReader();

    reader.onload = function () {

        let urlAdicionarImagem = 'https://mobtec-server-teste.herokuapp.com/painel/cadastrar-foto'

        axios.post(urlAdicionarImagem, {
            foto: reader.result,
            idCasa: idCasa,
            idCliente: idCliente
        }, auth).then(response => {
            location.reload();
        })
            .catch(error => alert(error))
    }
    reader.readAsDataURL(event.target.files[0]);
}

function listarImagens() {
    var urlListaImagens = 'https://mobtec-server-teste.herokuapp.com/painel/listar-fotos'

    axios.post(urlListaImagens, {

        //Body
        idCasa: idCasa,
        idCliente: idCliente

    })
        .then(response => {

            let result = "";
            result = response.data.map(data => (
                data
            ));

            result.forEach((result) => {

                html += '<li class="list-group-item d-flex justify-content-between align-items-center">' +
                    '<p class="card-text"><input type="button" class="btn btn-danger btn-sm"' +
                    'style="float:none!important;display:inline;" onclick="excluirImagem(' + result.idFoto + ')" value="Excluir" /></p>' +
                    '<img alt="Image" height="70" width="85"' +
                    'src="' + result.urlFoto + '"></img></li>'

                document.getElementById("listaImagens").innerHTML = html;
            })
        })
        .catch(error => {
            alert(error)
        })
}

function excluirImagem(imagemId) {

    let urlExcluir = 'https://mobtec-server-teste.herokuapp.com/painel/excluir-foto?idFoto=' + imagemId
    let resultado = confirm("Essa ação é irreversível, deseja continuar?");

    if (resultado == true) {
        axios.delete(urlExcluir, {
            // headers: { Authorization: `Bearer ${getToken}` }, data: {}
        });

        alert("Imagem excluida com Sucesso!")
    }

    listarImagens()
    location.reload();

}

function finalizar() {
    window.location.href = "../imoveis/lista.html";
}

function sair() {
    localStorage.removeItem("token");
    window.location.href = "../logar.html";
}