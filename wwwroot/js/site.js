// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var site = (function () {
    function VerificarDatosUsuario() {
        var form = document.getElementById("formRegistro");
        if (!form) return;

        var nombreUserElem = document.getElementById("NombreUsuarios");
        var passElem = document.getElementById("Contraseña");
        var nombreElem = document.getElementById("Nombre");
        var apellidoElem = document.getElementById("Apellido");

        var nombreUser = nombreUserElem ? nombreUserElem.value.trim() : "";
        var pass = passElem ? passElem.value : "";

        if (!pass || pass.length < 8) {
            alert("La contraseña debe tener al menos 8 caracteres.");
            if (passElem) passElem.focus();
            return;
        }

        if (!nombreUser || nombreUser.length < 4) {
            alert("El nombre de usuario debe tener al menos 4 caracteres.");
            if (nombreUserElem) nombreUserElem.focus();
            return;
        }

        // Si estamos en la página de registro, validar nombre y apellido
        if (nombreElem || apellidoElem) {
            var nombre = nombreElem ? nombreElem.value.trim() : "";
            var apellido = apellidoElem ? apellidoElem.value.trim() : "";

            if (!nombre || !apellido) {
                alert("Complete Nombre y Apellido.");
                return;
            }

            var alphaRegex = /^[A-Za-z]+$/;
            if (!alphaRegex.test(nombre)) {
                alert("Nombre con caracteres inválidos.");
                nombreElem.focus();
                return;
            }
            if (!alphaRegex.test(apellido)) {
                alert("Apellido con caracteres inválidos.");
                apellidoElem.focus();
                return;
            }
        }
        //Linea de codigo para enviar el formulario hacia el controlador
        form.submit();

    }
    return {
        VerificarDatosUsuario: VerificarDatosUsuario
    };
})();