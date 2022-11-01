const urlParams = new URLSearchParams(window.location.search);
const idCasa = urlParams.get('casa'); //pegar o valor da url casa
let clienteUrl = localStorage.getItem("clienteUrl")
let nomeCliente = "";
let tituloCasa = "";


//ListarConfigurações
var urlListarConfiguracao = 'https://mobtec-server-teste.herokuapp.com/site/listar-configuracoes/' + clienteUrl;

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



    })
    .catch(function (error) {
        console.log(error);
    })
    .finally(function () {
        // sempre executado
    });


let urlConfiguracoesCasa = 'https://mobtec-server-teste.herokuapp.com/site/listar-configuracoes-casa'
axios.post(urlConfiguracoesCasa, {

    //Body
    urlCliente: clienteUrl,
    idCasa: idCasa

})
    .then(response => {

        let cfgCasa = response.data;
        tituloCasa = cfgCasa.titulo

        document.getElementById("descricao").innerHTML += '<div class="small text-muted">Referência: ' + cfgCasa.idCasa + '</div>' +
            '<h2 class="card-title">' + cfgCasa.endereco + '</h2>' +
            '<p class="card-text">' + cfgCasa.descricao + '</p>' +
            '<br>' 
            // '<a class="btn btn-primary" href="#!">Entrar em contato</a>';


        document.getElementById("observacoes").innerHTML += '<p>Tipo: ' + cfgCasa.tipo + '</p>' +
            '<p>Valor: R$' + formatarMoeda(cfgCasa.valor) + '</p>' +
            '<p>Cidade: ' + cfgCasa.cidade + '</p>';

        document.getElementById("titulo").innerHTML += '<h2>' + cfgCasa.titulo + '</h2>';

    })
    .catch(error => {
        alert(error)
    })

let urlListaImagensDaCasa = 'https://mobtec-server-teste.herokuapp.com/site/listar-fotos-casa'
axios.post(urlListaImagensDaCasa, {

    //Body
    urlCliente: clienteUrl,
    idCasa: idCasa

})
    .then(response => {

        let imgs = "";
        let result = "";
        result = response.data.map(data => (
            data
        ));

        result.forEach((result) => {

            imgs += '<li data-responsive="' + result.urlFoto + ',' +
                '' + result.urlFoto + ',' +
                '' + result.urlFoto + '"' +
                'data-src="' + result.urlFoto + '"' +
                'data-sub-html="<h4>' + nomeCliente + '</h4><p>' + tituloCasa + '</p>">' +
                '<a href="">' +
                '<img class="img-responsive" style="width:300px; height:200px;"' +
                'src="' + result.urlFoto + '"></a></li>'

            document.getElementById("lightgallery").innerHTML = imgs;
        })

    })
    .catch(error => {
        alert(error)
    })

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