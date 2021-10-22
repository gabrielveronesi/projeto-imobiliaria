let getIdCliente = localStorage.getItem("idCliente")
localStorage.removeItem("token"); //Removendo idCliente do Cache por segurança


let urlListarDadosCliente = 'https://localhost:5001/adm/listar-dados-clientes';

function listarDadosCliente() {

    let body = {
        idCliente: getIdCliente,
    };

    axios.post(urlListarDadosCliente, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    }).then(response => {

        var dados = response.data;

        let formAtualizarCliente = "";
        let campoAtivo = '<option value="S">Sim</option><option value="N">Não</option>';

        if (dados.snAtivo == "N") {
            campoAtivo = '<option value="N">Não</option><option value="S">Sim</option>'
        }

        formAtualizarCliente +=

            '<label>Nome Comercial</label>' +
            '<input type="nmComercial" class="form-control" id="nmComercial"' +
            'value="' + dados.nomeComercial + '" placeholder="' + dados.nomeComercial + '">' +
            '<small id="" class="form-text text-muted">Nome Comercial</small>' +

            '<br>' +

            '<label>Nome do Cliente</label>' +
            '<input type="nmCliente" class="form-control" id="nmCliente"' +
            'value="' + dados.nomeCliente + '" placeholder="' + dados.nomeCliente + '">' +
            '<small id="" class="form-text text-muted">Nome do contratante do serviço</small>' +

            '<br>' +

            '<label>Numero de whatsapp</label>' +
            '<input type="noWhatsApp" class="form-control" id="noWhatsApp"' +
            'value="' + dados.whatsApp + '" placeholder="' + dados.whatsApp + '">' +
            '<small id="" class="form-text text-muted">Numero de whatsapp</small>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Numero de telefone</label>' +
            '<input type="noTelefone" class="form-control" id="noTelefone"' +
            'value="' + dados.telefone + '" placeholder="' + dados.telefone + '">' +
            '<small id="" class="form-text text-muted">Numero de telefone (não é whatsapp)</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Email</label>' +
            '<input type="email" class="form-control" id="email" ' +
            'value="' + dados.email + '" placeholder="' + dados.email + '">' +
            '<small id="" class="form-text text-muted">Email</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Endereco</label>' +
            '<input type="endereco" class="form-control" id="endereco" ' +
            'value="' + dados.endereco + '" placeholder="' + dados.endereco + '">' +
            '<small id="" class="form-text text-muted">Endereco</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Facebook</label>' +
            '<input type="facebook" class="form-control" id="facebook" ' +
            'value="' + dados.facebook + '" placeholder="' + dados.facebook + '">' +
            '<small id="" class="form-text text-muted">Facebook</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Instagram</label>' +
            '<input type="instagram" class="form-control" id="instagram" ' +
            'value="' + dados.instagram + '" placeholder="' + dados.instagram + '">' +
            '<small id="" class="form-text text-muted">Instagram</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Linkedin</label>' +
            '<input type="linkedin" class="form-control" id="linkedin" ' +
            'value="' + dados.linkedin + '" placeholder="' + dados.linkedin + '">' +
            '<small id="" class="form-text text-muted">Linkedin</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Youtube</label>' +
            '<input type="youtube" class="form-control" id="youtube" ' +
            'value="' + dados.youtube + '" placeholder="' + dados.youtube + '">' +
            '<small id="" class="form-text text-muted">Youtube</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label>Twitter</label>' +
            '<input type="twitter" class="form-control" id="twitter" ' +
            'value="' + dados.twitter + '" placeholder="' + dados.twitter + '">' +
            '<small id="" class="form-text text-muted">Twitter</small>' +
            '</div>' +

            '<br>' +

            '<div class="form-group">' +
            '<label for="exampleFormControlFile1">Logo</label>' +
            '<input type="file" class="form-control-file" id="exampleFormControlFile1">' +
            '</div>' +
            '<div id="info"></div>' +

            '<br>' +

            '<div class="input-group-prepend">' +
            '<span class="input-group-text">URL</span>' +
            '<input type="text" class="form-control" id="urlCliente" value="' + dados.urlCliente + '" placeholder="' + dados.urlCliente + '" aria-describedby="validationTooltipUsernamePrepend" required>' +
            '</div>' +
            '<div class="input-group-prepend">' +
            '<span class="input-group-text">USUARIO</span>' +
            '<input type="text" class="form-control" id="usuario" value="' + dados.usuario + '" placeholder="' + dados.usuario + '" aria-describedby="validationTooltipUsernamePrepend" required>' +
            '</div>' +
            '<div class="input-group-prepend">' +
            '<span class="input-group-text">SENHA</span>' +
            '<input type="text" class="form-control" id="senha" value="' + dados.senha + '" placeholder="' + dados.senha + '" aria-describedby="validationTooltipUsernamePrepend" required>' +
            '</div>' +

            '<br>' +


            '<div class="form-group">' +
            '<label for="exampleFormControlSelect1">Cliente está Ativo?</label>' +
            '<select class="form-control" id="ativo">' +
            campoAtivo +
            '</select>' +
            '</div>'

        document.getElementById("formAtualizarCliente").innerHTML = formAtualizarCliente;

    }).catch(function (error) {

        alert(error)

    }).finally(function () {
        // sempre executado
    });
}
listarDadosCliente();



function atualizarCliente() {

    let atualizarCliente = 'https://localhost:5001/adm/atualizar-cliente';
    let body = {

        idCliente: getIdCliente,
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
        twitter: document.querySelector('#twitter').value,
        urlCliente: document.querySelector('#urlCliente').value,
        usuario: document.querySelector('#usuario').value,
        senha: document.querySelector('#senha').value,
        snAtivo: document.querySelector('#ativo').value

    };

    axios.put(atualizarCliente, body)
        .catch(function (error) {
            alert(error)
            console.log(error)
        })
        .finally(function () {
            // sempre executado
        });

    alert("Cliente atualizado!")
}