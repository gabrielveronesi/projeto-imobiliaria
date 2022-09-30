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


var urlListaConfig = 'https://localhost:5001/painel/listar-configuracoes';


axios.post(urlListaConfig, { 

      idCliente: localStorage.getItem("idCliente") 
      
    })
     .then(response => {

      var _config = response.data;

    //#atualizaNomeComercial
    document.getElementById("atualizaNomeComercial").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Nome Comercial</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.nomeComercial + '" placeholder="' + _config.nomeComercial + '" required maxlength="40">' +
      '</div>'

    //#atualizaWhatsApp
    document.getElementById("atualizaWhatsApp").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">WhatsApp</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.whatsApp + '" placeholder="' + _config.whatsApp + '" required maxlength="40">' +
      '</div>'

    //#atualizaTelefone
    document.getElementById("atualizaTelefone").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Telefone</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.telefone + '" placeholder="' + _config.telefone + '" required maxlength="40">' +
      '</div>'

    //#atualizaEmail
    document.getElementById("atualizaEmail").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Email</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.email + '" placeholder="' + _config.email + '" required maxlength="40">' +
      '</div>'

    //#atualizaEndereco
    document.getElementById("atualizaEndereco").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Endereco</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.endereco + '" placeholder="' + _config.endereco + '" required maxlength="40">' +
      '</div>'
    
    //#atualizaFacebook
    document.getElementById("atualizaFacebook").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Facebook</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.facebook + '" placeholder="' + _config.facebook + '" required maxlength="40">' +
      '</div>'

    //#atualizaInstagram
    document.getElementById("atualizaInstagram").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Instagram</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.instagram + '" placeholder="' + _config.instagram + '" required maxlength="40">' +
      '</div>'

    //#atualizaLinkedin
    document.getElementById("atualizaLinkedin").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Linkedin</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.linkedin + '" placeholder="' + _config.linkedin + '" required maxlength="40">' +
      '</div>'

    //#atualizaYoutube
    document.getElementById("atualizaYoutube").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Youtube</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.youtube + '" placeholder="' + _config.youtube + '" required maxlength="40">' +
      '</div>'

    //#atualizaYoutube
    document.getElementById("atualizaYoutube").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Youtube</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.youtube + '" placeholder="' + _config.youtube + '" required maxlength="40">' +
      '</div>'

    //#atualizaTwitter
    document.getElementById("atualizaTwitter").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Twitter</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputNome" value="' + _config.twitter + '" placeholder="' + _config.twitter + '" required maxlength="40">' +
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

//   let urlAtualizarConfigs = 'https://localhost:5001/painel-adm/adicionar-configuracoes?emailCliente=' + getEmail;

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