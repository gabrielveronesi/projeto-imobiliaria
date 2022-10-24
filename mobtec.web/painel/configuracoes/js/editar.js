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
      '<input type="text" class="form-control" id="inputAtualizaNomeComercial" value="' + _config.nomeComercial + '" placeholder="' + _config.nomeComercial + '" required maxlength="40">' +
      '</div>'

    //#atualizaWhatsApp
    document.getElementById("atualizaWhatsApp").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">WhatsApp</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaWhatsApp" value="' + _config.whatsApp + '" placeholder="' + _config.whatsApp + '" required maxlength="40">' +
      '</div>'

    //#atualizaTelefone
    document.getElementById("atualizaTelefone").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Telefone</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaTelefone" value="' + _config.telefone + '" placeholder="' + _config.telefone + '" required maxlength="40">' +
      '</div>'

    //#atualizaEmail
    document.getElementById("atualizaEmail").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Email</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaEmail" value="' + _config.email + '" placeholder="' + _config.email + '" required maxlength="40">' +
      '</div>'

    //#atualizaEndereco
    document.getElementById("atualizaEndereco").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Endereco</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaEndereco" value="' + _config.endereco + '" placeholder="' + _config.endereco + '" required maxlength="40">' +
      '</div>'

    //#atualizaFacebook
    document.getElementById("atualizaFacebook").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Facebook</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaFacebook" value="' + _config.facebook + '" placeholder="' + _config.facebook + '">' +
      '</div>'

    //#atualizaInstagram
    document.getElementById("atualizaInstagram").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Instagram</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaInstagram" value="' + _config.instagram + '" placeholder="' + _config.instagram + '" >' +
      '</div>'

    //#atualizaLinkedin
    document.getElementById("atualizaLinkedin").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Linkedin</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaLinkedin" value="' + _config.linkedin + '" placeholder="' + _config.linkedin + '">' +
      '</div>'

    //#atualizaYoutube
    document.getElementById("atualizaYoutube").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Youtube</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaYoutube" value="' + _config.youtube + '" placeholder="' + _config.youtube + '" >' +
      '</div>'

    //#atualizaTwitter
    document.getElementById("atualizaTwitter").innerHTML = '<div class="input-group mb-3">' +
      '<div class="input-group-prepend">' +
      '<span class="input-group-text" id="basic-addon1">Twitter</span>' +
      '</div>' +
      '<input type="text" class="form-control" id="inputAtualizaTwitter" value="' + _config.twitter + '" placeholder="' + _config.twitter + '">' +
      '</div>'

  })
  .catch(error => {
    alert(error)
  })


let getToken = localStorage.getItem("token")

const auth = {
  headers: { Authorization: `Bearer ${getToken}` }
};

function salvarConfiguracoes() {

  let atualizaNomeComercial = document.querySelector('#inputAtualizaNomeComercial').value;
  let atualizaWhatsApp = document.querySelector('#inputAtualizaWhatsApp').value;
  let atualizaTelefone = document.querySelector('#inputAtualizaTelefone').value;
  let atualizaEmail = document.querySelector('#inputAtualizaEmail').value;
  let atualizaEndereco = document.querySelector('#inputAtualizaEndereco').value;
  let atualizaFacebook = document.querySelector('#inputAtualizaFacebook').value;
  let atualizaInstagram = document.querySelector('#inputAtualizaInstagram').value;
  let atualizaLinkedin = document.querySelector('#inputAtualizaLinkedin').value;
  let atualizaYoutube = document.querySelector('#inputAtualizaYoutube').value;
  let atualizaTwitter = document.querySelector('#inputAtualizaTwitter').value;

  let urlAdicionar = 'https://localhost:5001/painel/atualizar-configuracoes-geral'
  axios.post(urlAdicionar, {
    idCliente: localStorage.getItem("idCliente"),
    nomeComercial: atualizaNomeComercial,
    whatsApp: atualizaWhatsApp,
    telefone: atualizaTelefone,
    email: atualizaEmail,
    endereco: atualizaEndereco,
    facebook: atualizaFacebook,
    instagram: atualizaInstagram,
    linkedin: atualizaLinkedin,
    youtube: atualizaYoutube,
    twitter: atualizaTwitter

  }, auth)
    .then(response => {
      alert(response.data.mensagem)
    })
    .catch(error => {
      if (error.response.status == 401) {
        alert("Sua sessão expirou, faça o login novamente!")
        localStorage.removeItem("token");
        window.location.href = "../logar.html";
      } else {
        alert(error)
      }
    });

  location.reload();
}