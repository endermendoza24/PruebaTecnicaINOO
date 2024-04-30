using Dapper;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaIOON.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class DbManager
{
    private readonly IConfiguration _config;

    public DbManager(IConfiguration config)
    {
        _config = config;
    }

    private IDbConnection CreateConnection()
    {
        string connectionString = _config.GetConnectionString("DefaultConnection");
        return new SqlConnection(connectionString);
    }

    public void InsertarUsuario(Usuarios usuario)
    {
        using (IDbConnection dbConnection = CreateConnection())
        {
            string query = "INSERT INTO Usuarios (Nombre, Correo, Pass) VALUES (@Nombre, @Correo, @Pass)";
            dbConnection.Execute(query, usuario);
        }
    }

    public void InsertarNegocio(Negocios negocio)
    {
        using (IDbConnection dbConnection = CreateConnection())
        {
            string query = "INSERT INTO Negocios (Nombre, Direccion, RUC) VALUES (@Nombre, @Direccion, @RUC)";
            dbConnection.Execute(query, negocio);
        }
    }

    public bool ExisteUsuarioPorCorreo(string correo)
    {
        using (IDbConnection dbConnection = CreateConnection())
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo";
            int count = dbConnection.QueryFirstOrDefault<int>(query, new { Correo = correo });
            return count > 0;
        }
    }
}
