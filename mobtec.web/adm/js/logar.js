function logar() {
    let _user = document.querySelector('#inputUser').value
    let _pass = document.querySelector('#inputPass').value
    let _urlLoginAdm = 'https://mobtec-server-teste.herokuapp.com/adm/logar'

    if (_user == '' || _pass == '') {
        alert("Preencha os campos de login.")
        return;
    }

    let body = {
        usuario: _user,
        senha: _pass,
    };

    axios.post(_urlLoginAdm, body, {
        // headers: { Authorization: `Bearer ${getToken}` }
    }).then(response => {
        if (response.data.sucesso == false) {
            alert(response.data.mensagem);
        }
        else {
            window.location.href = "./cadastrarCliente.html";
            alert(response.data.mensagem);
        }
    }).catch(function (error) {
        alert(error)
    }).finally(function () {
        // sempre executado
    });
}
