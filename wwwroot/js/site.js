// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let site = (function () {
    function VerificarDatosUsuario() {
        let form = document.getElementById("formRegistro");
        if (!form) return;

        let nombreUserElem = document.getElementById("NombreUsuarios");
        let passElem = document.getElementById("Contraseña");
        let nombreElem = document.getElementById("Nombre");
        let apellidoElem = document.getElementById("Apellido");

        //agregar elementos de domicilio
        let calleElem = document.getElementById("Calle");
        let numeroElem = document.getElementById("Numero");
        let departamentoElem = document.getElementById("Departamento");

        let nombreUser = nombreUserElem ? nombreUserElem.value.trim() : "";
        let pass = passElem ? passElem.value : "";

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
            let nombre = nombreElem ? nombreElem.value.trim() : "";
            let apellido = apellidoElem ? apellidoElem.value.trim() : "";

            if (!nombre || !apellido) {
                alert("Complete Nombre y Apellido.");
                return;
            }

            let alphaRegex = /^[A-Za-z]+$/;
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

            //validar que la calle no este vacia y que el numero sea un numero

            let calle = calleElem ? calleElem.value.trim() : "";
            let numero = numeroElem ? numeroElem.value : "";

            if (!calle || !numero) {
                alert("Complete todos los campos de domicilio.");
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