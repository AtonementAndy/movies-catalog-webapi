using CatalogoFilmesApp.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CatalogoFilmesApp.Infrastructure.Service
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString = default!;

        public DbConnectionFactory(IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");

            if (connString is not null)
                _connectionString = connString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString); 
        }
    }
}
