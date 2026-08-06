// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function VerificarDatosUsuario(){
    const Contraseña = document.getElementById("Contraseña");
    const NombreUsuario = document.getElementById("NombreUsuarios");
    const Nombre = document.getElementById("Nombre");
    const Apellido = document.getElementById("Apellido");
    let i = 0;
    if(contraseña.Length < 8){
        "contraseña sin caracteres suficientes"
    }
    else{
        if(NombreUsuario.Length < 8){
            "nombre de usuario sin caracteres suficientes"
        }
        else{
            if(NombreUsuario.Length < 8){
                "nombre de usuario sin caracteres suficientes"
            }
            else{
                if(NuevoUsuario.usuariosRepetidos) //No tenemos usuario creado
                if(NombreUsuario == Users[i]){
                    "Nombre de usuario ya existente"
                }
                else{
                    if(!/^[A-Za-z]+$/.test(Nombre)){
                        "Nombre con caracteres inválidos"
                    }
                    else{
                        if(!/^[A-Za-z]+$/.test(Apellido)){
                        "Apellido con caracteres inválidos"
                        }
                        else{
                        document.getElementById("formRegistro").submit();
                        }
                    }
                }
            }
        }
    }
}