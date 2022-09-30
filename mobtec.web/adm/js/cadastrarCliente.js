function cadastrarCliente() {
    let _urlCadastrarCliente = 'https://localhost:5001/adm/cadastrar-cliente'

    let body = {

        nomeComercial: document.querySelector('#nmComercial').value,
        nomeCliente: document.querySelector('#nmCliente').value,
        logo: 'https://venngage-wordpress.s3.amazonaws.com/uploads/2019/04/Travel-Tour-Business-Logo.png',
        whatsApp: document.querySelector('#noWhatsApp').value,
        telefone: document.querySelector('#noTelefone').value,
        email: document.querySelector('#email').value,
        endereco: document.querySelector('#endereco').value,
        facebook: document.querySelector('#facebook').value,
        instagram: document.querySelector('#instagram').value,
        linkedin: document.querySelector('#linkedin').value,
        youtube: document.querySelector('#youtube').value,
        twitter: document.querySelector('#twitter').value

    };

    axios.post(_urlCadastrarCliente, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    }).then(response => {

        console.log(response.data.idCliente)
        alert("Cliente cadastrado com sucesso");
        alert("ID CLIENTE: " + response.data.idCliente + "\n" + 
              "URL DO CLIENTE: " + response.data.urlCliente +  "\n" +
              "USUARIO: " + response.data.usuario +  "\n" +
              "SENHA: " + response.data.senha );


    }).catch(function (error) {

      alert(error)

    }).finally(function () {
        // sempre executado
    });

    alert("Realizando cadastro....")
}