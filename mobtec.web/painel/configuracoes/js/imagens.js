$(function () {
  'use strict'

  $('[data-toggle="offcanvas"]').on('click', function () {
    $('.offcanvas-collapse').toggleClass('open')
  })
})

function sair() {
  localStorage.removeItem("token");
  window.location.href = "../logar.html";
}


var urlListaConfig = 'https://mobtec-server-teste.herokuapp.com/painel/listar-configuracoes';


axios.post(urlListaConfig, { 

      idCliente: localStorage.getItem("idCliente") 
      
    })
     .then(response => {

      var _config = response.data;

    //#atualizaNomeComercial
    document.getElementById("atualizaNomeComercial").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Bannerxxxx precisa terminar!...</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.nomeComercial + '" placeholder="' + _config.nomeComercial + '" required maxlength="40">' +
      '</div>'

    })
    .catch(error => {
        alert(error)
    })
  
























// let getToken = localStorage.getItem("token")
// let getEmail = localStorage.getItem("user")
 
// const auth = {
//   headers: { Authorization: `Bearer ${getToken}` }
// };

// axios.get(urlListaConfig, auth)
//   .then(function (response) {

//     var json   = response.data;
//     var _result = json.data.value;

//     //#Atualiza Nome
//     document.getElementById("atualizaNome").innerHTML = '<div class="input-group mb-3">' +
//       '<div class="input-group-prepend">' +
//       '<span class="input-group-text" id="basic-addon1">Nome</span>' +
//       '</div>' +
//       '<input type="text" class="form-control" id="inputNome" value="' + _result.nome + '" placeholder="' + result.nome + '" required maxlength="40">' +
//       '</div>'

//     //#Atualiza Sobre
//     document.getElementById("atualizaSobre").innerHTML = '<div class="input-group">' +
//       '<div class="input-group-prepend">' +
//       '<span class="input-group-text">Sobre</span>' +
//       '</div>' +
//       '<textarea class="form-control" id="inputSobre" aria-label="Com textarea" maxlength="500">' + _result.sobre + '</textarea>' +
//       '</div>'

//     //#Atualiza Texto - Rodapé
//     document.getElementById("atualizaTexto").innerHTML = '<div class="input-group">' +
//       '<div class="input-group-prepend">' +
//       '<span class="input-group-text">Rodapé</span>' +
//       '</div>' +
//       '<textarea class="form-control" id="inputTexto" aria-label="Com textarea" maxlength="100">' + _result.texto + '</textarea>' +
//       '</div>'

//     //#Atualiza Contatos
//     document.getElementById("atualizaContatos").innerHTML =
//       //Facebook
//       '<div class="input-group mb-3">' +
//       '<div class="input-group-prepend">' +
//       '<span class="input-group-text" id="basic-addon3">Facebook&nbsp;</span>' +
//       '</div>' +
//       '<input type="text" class="form-control" id="inputFacebook" aria-describedby="basic-addon3" value="' + _result.facebook + '" placeholder="' + _result.facebook + '" maxlength="100">' +
//       '</div>' +
//       //Instagram
//       '<div class="input-group mb-3">' +
//       '<div class="input-group-prepend">' +
//       '<span class="input-group-text" id="basic-addon3">Instagram</span>' +
//       '</div>' +
//       '<input type="text" class="form-control" id="inputInstagram" aria-describedby="basic-addon3" value="' + _result.instagram + '" placeholder="' + _result.instagram + '" maxlength="100">' +
//       '</div>' +
//       //WhatsApp
//       '<div class="input-group mb-3">' +
//       '<div class="input-group-prepend">' +
//       '<span class="input-group-text" id="basic-addon3">WhatsApp</span>' +
//       '</div>' +
//       '<input type="number" class="form-control" id="inputWhatsapp" aria-describedby="basic-addon3" value="' + result.whatsApp + '" placeholder="' + result.whatsApp + '" maxlength="100">' +
//       '</div>'
//   })
//   .catch(function (error) {
//     console.log(error);
//   })
//   .finally(function () {
//     // sempre executado
//   });

// function salvarConfiguracoes() {

//   let nome = document.querySelector('#inputNome').value
//   let sobre = document.querySelector('#inputSobre').value
//   let texto = document.querySelector('#inputTexto').value
//   let facebook = document.querySelector('#inputFacebook').value
//   let instagram = document.querySelector('#inputInstagram').value
//   let whatsapp = document.querySelector('#inputWhatsapp').value

//   let urlAtualizarConfigs = 'https://mobtec-server-teste.herokuapp.com/painel-adm/adicionar-configuracoes?emailCliente=' + getEmail;

//   let body = {
//     nome: nome,
//     sobre: sobre,
//     texto: texto,
//     facebook: facebook,
//     instagram: instagram,
//     whatsApp: whatsapp
//   };

//   axios.post(urlAtualizarConfigs, body, {
//     headers: { Authorization: `Bearer ${getToken}` }
//   })
//     .catch(function (error) {
//       window.location.href = "../logar.html";
//     })
//     .finally(function () {
//       // sempre executado
//     });
    
//   alert("Configurações atualizadas!")
//   location.reload();

// }