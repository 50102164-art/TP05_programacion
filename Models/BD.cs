namespace TP05.Models;
using Microsoft.Data.SqlClient;
using Dapper;

public class BD{
    private static string _connectionString = "Server=localhost;Database=Login;Integrated Security=True;TrustServerCertificate=True;";
    public List <Usuarios> TraerUsuarios(){
        List <Usuarios> Users = new List <Usuarios>();
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            string query = "SELECT * FROM Usuarios";
            Users = connection.Query<Usuarios>(query).ToList();
        }
        return Users;
    }

    public void RegistrarUsuarios(Usuarios UsuarioNuevo){
        string query ="INSERT INTO Usuarios (NombreUsuarios, Contraseña, Nombre, Apellido, TipoUsuario) VALUES (@NombreUsuarios, @Contraseña, @Nombre, @Apellido, @TipoUsuario)";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            connection.Execute(query, UsuarioNuevo);
        }   
    }

    public int RegistrarUsuariosRetornandoId(Usuarios UsuarioNuevo){
        string query ="INSERT INTO Usuarios (NombreUsuarios, Contraseña, Nombre, Apellido, TipoUsuario) VALUES (@NombreUsuarios, @Contraseña, @Nombre, @Apellido, @TipoUsuario); SELECT CAST(SCOPE_IDENTITY() AS INT);";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            int id = connection.ExecuteScalar<int>(query, UsuarioNuevo);
            return id;
        }
    }

    public Usuarios ObtenerUsuarioPorCredenciales(string nombreUsuario, string contraseña){
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE NombreUsuarios = @nombreUsuario AND Contraseña = @contraseña";
            var usuario = connection.QueryFirstOrDefault<Usuarios>(query, new { nombreUsuario, contraseña });
            return usuario;
        }
    }

    public bool BuscarSiExisteUnUsuario(string NombreUsuario){
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuarios = @NombreUsuario";
            int count = connection.ExecuteScalar<int>(query, new { NombreUsuario });
            return count > 0;
        }
    }
}