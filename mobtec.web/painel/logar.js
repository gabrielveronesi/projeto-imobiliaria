let urlLogin = 'https://localhost:5001/painel/logar'

function logar() {
    let email = document.querySelector('#inputEmail').value
    let pass = document.querySelector('#inputPassword').value

    axios.post(urlLogin, {
        //Body
        usuario: email,
        senha: pass
    })
        .then(response => {
            if (response.data.sucesso == false) {
                document.getElementById("error").innerHTML = '<div class="alert alert-danger" role="alert">' + response.data.mensagem + ' </div>'
            }
            else {
                document.getElementById("error").innerHTML = '<div class="alert alert-success" role="alert">' + response.data.message + ' </div>'

                let token = response.data.token;
                let idCliente = response.data.idCliente;

                localStorage.setItem("token", token)
                localStorage.setItem("idCliente", idCliente)

                window.location.href = "./imoveis/lista.html";
            }
        })
        .catch(error => {
            document.getElementById("error").innerHTML = '<div class="alert alert-danger" role="alert">' + error + ' </div>'
        })
}
