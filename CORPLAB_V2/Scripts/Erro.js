$(document).ready(function () {



});
/////////////////////////////////////////////////////////////////////////////////////////////
function Redireciona(tipo) {

    var destino = "../Home/Home.aspx";

    if (tipo == 1) {
        destino = "../Login/Login.aspx";
    }

    window.location.href = destino;
}
