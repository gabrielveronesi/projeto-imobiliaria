$(function () {
    'use strict'

    $('[data-toggle="offcanvas"]').on('click', function () {
        $('.offcanvas-collapse').toggleClass('open')
    })

    listarImagens();
})

let urlAdicionar = 'https://localhost:5001/cliente-autenticado/cadastrar-casa'
let getToken = localStorage.getItem("token")
let getCasaId = localStorage.getItem("casaId")
let html = "";


const auth = {
    headers: { Authorization: `Bearer ${getToken}` }
};

var loaderFile = function (event) {
    var reader = new FileReader();

    reader.onload = function () {

        let urlAdicionarImagem = 'https://localhost:5001/cliente-autenticado/cadastrar-imagem'
        let idRandon = Math.floor(Math.random() * 9999999999)
        let text = reader.result;

        console.log(reader);

        let resultado = text.replace("data:image/jpeg;base64,", ""); //TODO: colocar outros formatos!

        axios.post(urlAdicionarImagem, {
            imagemId: idRandon.toString(),
            addImagem: resultado,
            casaId: getCasaId
        }, auth).then(response => {

            location.reload();
        })
            .catch(error => alert(error))
    }

    reader.readAsDataURL(event.target.files[0]);

}

function listarImagens() {
    var urlListaImagens = 'https://localhost:5001/publico/listar-imagens?casaId=' + getCasaId
    axios.get(urlListaImagens, auth)
        .then(function (response) {

            let json = response.data;
            let result = "";

            result = json.data.value.map(data => (
                data
            ));

            result.forEach((result) => {

                var a = "data:image/jpeg;base64,"; //TODO: colocar outros formatos!
                var b = result.addImagem;
                var concatenado = a.concat(b);

                html += '<li class="list-group-item d-flex justify-content-between align-items-center">' +
                    '<p class="card-text"><input type="button" class="btn btn-danger btn-sm"' +
                    'style="float:none!important;display:inline;" onclick="excluirImagem(' + result.imagemId + ')" value="Excluir" /></p>' +
                    '<img alt="Image" height="70" width="85"' +
                    'src="' + concatenado + '"></img>' +
                    '</li>'

                document.getElementById("listaImagens").innerHTML = html;
            });
        })
        .catch(function (error) {
            console.log(error);
        })
        .finally(function () {
            // sempre executado
        });
}

function excluirImagem(imagemId) {

    let urlExcluir = 'https://localhost:5001/cliente-autenticado/deletar-imagem?imagemId=' + imagemId
    let resultado = confirm("Essa ação é irreversível, deseja continuar?");

    if (resultado == true) {
        axios.delete(urlExcluir, {
            headers: { Authorization: `Bearer ${getToken}` }, data: {}
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