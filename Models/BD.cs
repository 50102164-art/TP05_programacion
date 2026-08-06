namespace TP05.Models;

public class BD{
    
}

public List <Usuarios> TraerUsuarios(){
    List <Usuarios> Users = new List <Usuarios>();
    using (SqlConnection connection = new SqlConnection (_connectionString))
    {
        string query = "SELECT * FROM Usuarios";
        Users= connection.Query<Usuarios>(query).ToList();
    }
    return Users; 
}

public void RegistrarUsuarios(Usuarios UsuarioNuevo){

    string query = "INSERT INTO Usuarios (IdUsuario, NombreUsuario, Contraseña, Nombre, Apellido, TipoUsuario) VALUES (@pIdUsuario, @pNombreUsuarios, @pContraseña, @pNombre, @pApellido, @pTipoUsuario)";
    using (SqlConnection connection = new SqlConnection (_connectionString))
    {
        connection.Execute(query, new { pIdUsuario = UsuarioNuevo.IdUsuario, pNombreUsuario = UsuarioNuevo.NombreUsuario, pContraseña, UsuarioNuevo.Contraseña, pNombre = UsuarioNuevo.Nombre, pApellido = UsuarioNuevo.Apellido, pTipoUsuario = UsuarioNuevo.TipoUsuario});
    }
}