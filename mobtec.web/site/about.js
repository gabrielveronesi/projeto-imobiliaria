const urlParams = new URLSearchParams(window.location.search);
let text = urlParams.toString();
let clienteUrl = text.replace("=", "");


//ListarConfigurações
var urlListarConfiguracao = 'https://localhost:5001/site/listar-configuracoes/' + clienteUrl;

axios.get(urlListarConfiguracao)
    .then(function (configuracoes) {

        let _configuracoes = configuracoes.data;

        if (_configuracoes.snAtivo == "N") {
            alert("Cliente não está ativo, TODO: Exibir um erro, e não exibir a pagina!!")
        }

        nomeCliente = _configuracoes.nomeComercial

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
    
        document.getElementById("descricaoSobre").innerHTML = '<p class="margin_0">' + _configuracoes.descricaoSobre + '</p>';
        document.getElementById("bannerSobre").innerHTML = '<figure><img src="'+_configuracoes.bannerSobre+'"alt="#" /></figure></p>';

    })
    .catch(function (error) {
        console.log(error);
    })
    .finally(function () {
        // sempre executado
    });