using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Xml.Linq;

namespace IntJob.DataAccess.DbAccess
{
    public class SqliteDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqliteDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqliteConnection createConnection(string connectionId)
        {
            string connectionString = _configuration.GetConnectionString(connectionId) ??
                throw new ArgumentNullException(nameof(connectionString));

            if (connectionString.Contains("{AppDir}"))
            {
                DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());

                string[] parts = connectionString.Split("{AppDir}");

                string path = Directory.CreateDirectory(
                    Path.Combine(di.Parent?.FullName ?? di.FullName, parts[1]))
                    .ToString();

                connectionString = parts[0] + path;
            }            

            return new SqliteConnection(connectionString);
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using SqliteConnection connection = createConnection(connectionId);
            connection.Open();

            return await connection.QueryAsync<T>(storedProcedure, parameters);
        }

        public async Task<T> SaveData<T,U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using SqliteConnection connection = createConnection(connectionId);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters);
        }

    }
}

