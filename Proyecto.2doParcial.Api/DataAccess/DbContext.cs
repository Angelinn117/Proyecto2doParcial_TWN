using System.Data.Common;
using MySqlConnector;
using Proyecto._2doParcial.DataAccess.Interfaces;

namespace Proyecto._2doParcial.DataAccess;

public class DbContext : IDbContext
{
    private readonly string _connectionString = "server=localhost;user=root;database=project2ndpartial_db;password=TWM12345";

    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            return _connection;
        }
    }
}