const urlParams = new URLSearchParams(window.location.search);
let text = urlParams.toString();
let clienteUrl = text.replace("=", "");
localStorage.setItem("clienteUrl", clienteUrl);
let clienteWhatsapp = "";
let getBuscaSite = localStorage.getItem("buscaSite")
let getPaginaNumeroSite = localStorage.getItem("paginaNumeroSite")

if (getPaginaNumeroSite == null) {
    getPaginaNumeroSite = 1
}

var urlListarConfiguracao = 'https://localhost:5001/site/listar-configuracoes/' + clienteUrl;
axios.get(urlListarConfiguracao)
    .then(function (configuracoes) {

        let _configuracoes = configuracoes.data;

        if (_configuracoes.snAtivo == "N") {
            alert("Cliente não está ativo, TODO: Exibir um erro, e não exibir a pagina!!")
        }

        var banner01;
        var banner02;
        var banner03;

        if (_configuracoes.banner01 == null)
            banner01 = '../site/images/banner1.jpg'
        else banner01 = _configuracoes.banner01

        if (_configuracoes.banner01 == null)
            banner02 = '../site/images/banner2.jpg'
        else banner02 = _configuracoes.banner02

        if (_configuracoes.banner01 == null)
            banner03 = '../site/images/banner3.jpg'
        else banner03 = _configuracoes.banner03

        clienteWhatsapp = _configuracoes.whatsApp


        document.getElementById("Logo").innerHTML = '<a href="index.html?' + clienteUrl + '"><img style="width:150px" src=" ' + _configuracoes.logo + ' " alt="#" /></a>';
        document.getElementById("Carrossel").innerHTML =
            '<div class="carousel-inner">' +
            '<div class="carousel-item active">' +
            '<img class="first-slide" style="width:1000%; height:600px" src="' + banner01 + '" alt="First slide"></div>' +
            '<div class="carousel-item">' +
            '<img class="second-slide" style="width:1000%; height:600px" src="' + banner02 + '" alt="Second slide"></div>' +
            '<div class="carousel-item">' +
            '<img class="third-slide" style="width:1000%; height:600px" src="' + banner03 + '" alt="Third slide">' +
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
        window.location.href = 'error.html'
    })
    .finally(function () {
        // sempre executado
    });


var urlListarCasasDestaque = 'https://localhost:5001/site/listar-casas-destaque?urlCliente=' + clienteUrl;
axios.post(urlListarCasasDestaque, {})
    .then(response => {

        let tableText = "";
        let json = response.data;

        json.forEach((casasDestaque) => {
            tableText +=
                '<div class="container">' +
                '<div class="row">' +
                '<div class="col-md-12">' +
                '<div class="titlepage">' +
                '<h2>Imóveis em destaque</h2>' +
                '<p>Confira algum dos nossos imóveis em destaque.</p>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-md-4">' +
                '<div class="blog_box">' +
                '<div class="blog_img">' +
                '<a href="apresentacao.html?' + clienteUrl + '&casa=' + casasDestaque.idCasa + '">' +
                '<figure><img src="images/blog1.jpg" alt="#" /></figure>' +
                '</div>' +
                ' <div class="blog_room">' +
                ' <h3>' + casasDestaque.titulo + '</h3>' +
                ' <span>R$' + formatarMoeda(casasDestaque.valor) + '</span>' +
                '<p>' + casasDestaque.pequenaDescricao + '</p>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
        })

        document.getElementById("ListaCasasDestaque").innerHTML = tableText

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

function mudarPagina(numeroPagina) {
    localStorage.setItem("paginaNumeroSite", numeroPagina);
    location.reload();
}

function buscarCasaFiltro() {
    //localStorage.setItem("paginaNumeroSite", numeroPagina);
    var finalidade = document.querySelector('#filtroFinalidade').value
    var cidade = document.querySelector('#filtroCidade').value
    var endereco = document.querySelector('#filtroEndereco').value

    window.location.href = 'casas.html?' + clienteUrl + '&finalidade=' + finalidade + '&cidade=' + cidade + '&endereco=' + endereco

}

function enviarMensagem() {
    let inputNome = document.querySelector('#inputNome').value
    let inputEmail = document.querySelector('#inputEmail').value
    let inputTelefone = document.querySelector('#inputTelefone').value
    let inputMensagem = document.querySelector('#inputMensagem').value

    clienteWhatsapp = clienteWhatsapp.replace('(', '');
    clienteWhatsapp = clienteWhatsapp.replace(')', '');
    clienteWhatsapp = clienteWhatsapp.replace('-', '');
    clienteWhatsapp = clienteWhatsapp.replace(' ', '');
    clienteWhatsapp = clienteWhatsapp.replace('  ', '');

    let mensagem = ' ' + inputMensagem + ' Meu celular: ' + inputTelefone + ' E-mail: ' + inputEmail + ' Nome: ' + inputNome
    mensagem = mensagem.replace(' ', '%20')

    window.location.href = 'https://api.whatsapp.com/send?phone=+55' + clienteWhatsapp + '&text=' + mensagem;
}