using Dapper;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaIOON.Models;
using System.Data;
using System.Data.SqlClient;

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

    public void InsertarUsuario(Usuarios usuarios)
    {
        using (IDbConnection dbConnection = CreateConnection())
        {
            string query = "INSERT INTO Usuarios (Nombre, Email, Pass) VALUES (@Nombre, @Email, @Pass)";
            dbConnection.Execute(query, usuarios);
        }
    }

    public void InsertarNegocio(Negocios negocios)
    {
        using (IDbConnection dbConnection = CreateConnection())
        {
            string query = "INSERT INTO Negocios (Nombre, Direccion, RUC) VALUES (@Nombre, @Direccion, @RUC)";
            dbConnection.Execute(query, negocios);
        }
    }
}
