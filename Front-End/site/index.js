const urlParams = new URLSearchParams(window.location.search);
let text = urlParams.toString();
let clienteUrl = text.replace("=", "");
localStorage.setItem("clienteUrl", clienteUrl);

//ListarConfigurações
var urlListarConfiguracao = 'https://localhost:5001/site/listar-configuracoes/' + clienteUrl;

let getBuscaSite = localStorage.getItem("buscaSite")
let getPaginaNumeroSite = localStorage.getItem("paginaNumeroSite")

if (getPaginaNumeroSite == null) {
    getPaginaNumeroSite = 1
}

axios.get(urlListarConfiguracao)
    .then(function (configuracoes) {

        let _configuracoes = configuracoes.data;

        if (_configuracoes.snAtivo == "N") {
            alert("Cliente não está ativo, TODO: Exibir um erro, e não exibir a pagina!!")
        }

        document.getElementById("Logo").innerHTML = '<a href=""><img width="80" height="80" src=" ' + _configuracoes.logo + ' " alt="#" /></a>';
        document.getElementById("Carrossel").innerHTML =
            '<div class="carousel-inner">' +
            '<div class="carousel-item active">' +
            '<img class="first-slide" style="width:1000%; height:600px" src="' + _configuracoes.banner01 + '" alt="First slide"></div>' +
            '<div class="carousel-item">' +
            '<img class="second-slide" style="width:1000%; height:600px" src="' + _configuracoes.banner02 + '" alt="Second slide"></div>' +
            '<div class="carousel-item">' +
            '<img class="third-slide" style="width:1000%; height:600px" src="' + _configuracoes.banner03 + '" alt="Third slide">' +
            '</div></div>';

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
            '<li class="active"><a href="#">Home</a></li>' +
            '<li><a href="about.html">Sobre</a></li>' +
            '<li><a href="room.html">Contatos</a></li>' +
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
    })
    .finally(function () {
        // sempre executado
    });

var urlListarCasas = 'https://localhost:5001/site/listar-casas-site'
axios.post(urlListarCasas, {

    //Body
    urlCliente: clienteUrl,
    paginaParametros: {
        paginaNumero: getPaginaNumeroSite,
        paginaTamanho: 9,
        busca: null
    }

})
    .then(response => {

        let tableText = "";
        let totalPaginas = 0;
        let paginacao = "";

        let json = response.data;
        json.forEach((casas) => {

            tableText +=
                '<div class="col-md-4 col-sm-6">' +
                '<div id="serv_hover" class="room">' +
                '<div class="room_img">' +
                '<a href="apresentacao.html">' +
                '<figure><img src="images/blog2.jpg" alt="about.html" /></figure>' +
                '</a>' +
                '</div>' +
                '<div class="bed_room">' +
                '<h1>' + casas.titulo + '</h1>' +
                '<p>' + casas.pequenaDescricao + '</p>' +
                '<p3> Referencia:' + casas.idCasa + '</p3>' +
                '<br>' +
                '<strong>' +
                '<p>R$' + formatarMoeda(casas.valor) + '</p>' +
                '</strong>' +
                '</div>' +
                '</div>' +
                '</div>'

            totalPaginas = casas.totalPaginas;

        })

        var paginacaotxt = '';
        for (let index = 1; index <= totalPaginas; index++) {

            //paginacaotxt = paginacaotxt + '<button class="btn btn-outline-warning my-lg-2 my-sm-2" style="margin: 0;" onclick="addPagina('+index+')" style="margin:15px;">' + index + '</button>'
            paginacaotxt = paginacaotxt + '<li class="page-item"><a class="page-link" onclick="mudarPagina(' + index + ')">' + index + '</a></li>'

        }

        paginacao += paginacaotxt

        document.getElementById("ListaCasas").innerHTML = tableText
        document.getElementById("Paginacao").innerHTML = paginacao;

    })
    .catch(function (error) {
        console.log(error);
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

function mudarPagina(numeroPagina) {
    localStorage.setItem("paginaNumeroSite", numeroPagina);
    location.reload();
}

