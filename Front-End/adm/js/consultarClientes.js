let _urlListaClientes = 'https://localhost:5001/adm/listar-clientes';

function listarClientes() {

    axios.get(_urlListaClientes)
    .then(function (response) {

        let result = response.data.map(data => (
            data
        ));

        let tableText = "";
        result.forEach((cliente) => {
            
            tableText += '<tr>' +
            '<th scope="row">'+cliente.idCliente+'</th>' +
            '<td>'+cliente.nomeComercial+'</td>' +
            '<td>'+cliente.nomeCliente+'</td>' +
            '<td>'+cliente.urlCliente+'</td>' +
            '<td>'+cliente.snAtivo+'</td>' +
            '<td>'+'<button type="button" onclick="atualizarCliente('+cliente.idCliente+')" class="btn btn-warning">Atualizar</button>'+'</td>' +
            '</tr>';

            document.getElementById("colunaNomeCliente").innerHTML = tableText;

        });
           
        })
    .catch(function (error) {
        alert(error)
    })
    .finally(function () {
        // sempre executado
    });
    
}
listarClientes();

function atualizarCliente(idCliente) {

    localStorage.setItem("idCliente", idCliente)
    window.location.href = "./atualizarCliente.html";
}



