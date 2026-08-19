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

    public List <Domicilio> TraerDomicilios(){
        List <Domicilio> Domicilios = new List <Domicilio>();
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            string query = "SELECT * FROM Domicilio";
            Domicilios = connection.Query<Domicilio>(query).ToList();
        }
        return Domicilios;
    }

    public void RegistrarUsuarios(Usuarios UsuarioNuevo){
        string query ="INSERT INTO Usuarios (NombreUsuarios, Contraseña, Nombre, Apellido, TipoUsuario, IdDomicilio) VALUES (@NombreUsuarios, @Contraseña, @Nombre, @Apellido, @TipoUsuario, @IdDomicilio)";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            connection.Execute(query, UsuarioNuevo);
        }   
    }

    //Crea una función que registre un domicilio en la base de datos
    public void RegistrarDomicilio(Domicilio DomicilioNuevo){
        string query ="INSERT INTO Domicilio (Calle, Numero, Departamento) VALUES (@Calle, @Numero, @Departamento)";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            connection.Execute(query, DomicilioNuevo);
        }   
    }

    public int RegistrarDomicilioRetornandoId(Domicilio DomicilioNuevo){
        string query ="INSERT INTO Domicilio (Calle, Numero, Departamento) VALUES (@Calle, @Numero, @Departamento); SELECT CAST(SCOPE_IDENTITY() AS INT);";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            int id = connection.ExecuteScalar<int>(query, DomicilioNuevo);
            return id;
        }
    }

    public int RegistrarUsuariosRetornandoId(Usuarios UsuarioNuevo){
        string query ="INSERT INTO Usuarios (NombreUsuarios, Contraseña, Nombre, Apellido, TipoUsuario, IdDomicilio) VALUES (@NombreUsuarios, @Contraseña, @Nombre, @Apellido, @TipoUsuario, @IdDomicilio); SELECT CAST(SCOPE_IDENTITY() AS INT);";
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