const urlParams = new URLSearchParams(window.location.search);
let clienteWhatsapp = "";
const finalidade = urlParams.get('finalidade');
const cidade = urlParams.get('cidade');
const endereco = urlParams.get('endereco');
let clienteUrl = localStorage.getItem("clienteUrl")


var urlListarConfiguracao = 'https://localhost:5001/site/listar-configuracoes/' + clienteUrl;
axios.get(urlListarConfiguracao)
    .then(function (configuracoes) {

        let _configuracoes = configuracoes.data;

        if (_configuracoes.snAtivo == "N") {
            alert("Cliente não está ativo, TODO: Exibir um erro, e não exibir a pagina!!")
        }
        clienteWhatsapp = _configuracoes.whatsApp

        document.getElementById("Logo").innerHTML = '<a href="index.html?' + clienteUrl + '"><img style="width:150px" src=" ' + _configuracoes.logo + ' " alt="#" /></a>';

        document.getElementById("_Footer").innerHTML =
            '<div class="row">' +
            '<div class=" col-md-4">' +
            '<h3>Contatos</h3>' +
            '<ul class="conta">' +
            '<li><i class="fa fa-map-marker" aria-hidden="true"></i>' + _configuracoes.endereco + '</li>' +
            '<li><i class="fa fa-mobile" aria-hidden="true"></i>' + _configuracoes.telefone + '</li>' +
            '<li> <i class="fa fa-envelope" aria-hidden="true"></i><a href="#">' + _configuracoes.email + '</a></li>' +
            '</ul>' +
            '</div>' +
            '<div class="col-md-4">' +
            '<h3>Menu Link</h3>' +
            '<ul class="link_menu">' +
            '<li><a href="index.html?' + clienteUrl + '">Home</a></li>' + 
            '<li><a href="about.html?' + clienteUrl + '">Sobre</a></li>' +
            '<li><a href="contact.html?' + clienteUrl + '">Contato</a></li>' +
            '</ul>' +
            '</div>' +
            '<div class="col-md-4">' +
            '<ul class="social_icon">' +
            '<li><a href="' + _configuracoes.facebook + '"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>' +
            '<li><a href="' + _configuracoes.twitter + '"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>' +
            '<li><a href="' + _configuracoes.linkedin + '"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>' +
            '<li><a href="' + _configuracoes.youtube + '"><i class="fa fa-youtube-play" aria-hidden="true"></i></a></li>' +
            '</ul>' +
            '</div>' +
            '</div>';
    })
    .catch(function (error) {
        console.log(error);
        window.location.href = 'error.html'
    })
    .finally(function () {
        // sempre executado
    });

var urlListarCasasFiltro = 'https://localhost:5001/site/listar-casas-filtro'
axios.post(urlListarCasasFiltro, {

    //Body
    urlCliente: clienteUrl,
    finalidade: finalidade,
    cidade: cidade,
    endereco: endereco

})
    .then(response => {
        let tableText = "";
        let json = response.data;

        json.forEach((casas) => {

            tableText +=
                '<div class="col-md-4 col-sm-6">' +
                '<div id="serv_hover" class="room">' +
                '<div class="room_img">' +
                '<a href="apresentacao.html?' + clienteUrl + '&casa=' + casas.idCasa + '">' +
                '<figure><img src="images/blog2.jpg" alt="about.html" /></figure>' +
                '</a>' +
                '</div>' +
                '<div class="bed_room">' +
                '<h1>' + casas.titulo + '</h1>' +
                '<p>' + casas.pequenaDescricao + '</p>' +
                '<p3> Referencia: ' + casas.idCasa + '</p3>' +
                '<br>' +
                '<strong>' +
                '<p>R$' + formatarMoeda(casas.valor) + '</p>' +
                '</strong>' +
                '</div>' +
                '</div>' +
                '</div>'

        })

        document.getElementById("ListaCasas").innerHTML = tableText

    })
    .catch(function (error) {
        console.log(error);
        window.location.href = 'error.html'
    })
    .finally(function () {
        // sempre executado
    });


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
