namespace TP05.Models;

public class Usuarios
{
    public int IdUsuario{get; set;};
    public string NombreUsuarios{get; set;};
    public string Contraseña{get; set;};
    public string Nombre{get; set;};
    public string Apellido{get; set;};
    public string TipoUsuario{get; set;};

    public List<Usuarios> Users = new List<Usuarios>;

}

public bool usuariosRepetidos(Usuarios UsuarioNuevo)
{
    BD bd = new BD();
    Users = bd.TraerUsuarios();
    int i = 0;
    bool validacion = true;
    while(UsuarioNuevo != Users[i] && i < Users.Count())
    {
        i++;
    }
    if(i < Users.Count()){
        validacion = false;
    }
    return validacion;
}