function logar() {
    let _user = document.querySelector('#inputUser').value
    let _pass = document.querySelector('#inputPass').value
    let _urlLoginAdm = 'https://localhost:5001/adm/logar'


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

    alert(error) //precisa disso não sei porque, se não a pagina não carrega!
}
