namespace TP05.Models;
using Microsoft.Data.SqlClient;
using Dapper;

public class BD{
    private static string _connectionString = "Server=localhost;Database=LoginRegistro;TrustServerCertificate=True;";
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
}