using Microsoft.Data.Sqlite;
using Dapper;

namespace DataStore
{
	public class DataStore
	{
		static readonly string _connectionString = "Data Source=db.sqlite3";

		public static int Save(CrudObject obj)
		{
			string sql;
			if (obj.Id == 0)
			{
				sql = obj.CreateSql;
			} else
			{
				sql = obj.UpdateSql;
			}

			//var sql = "INSERT INTO Customers (Name, Address) VALUES (@Name, @Address); SELECT last_insert_rowid();";

			using var connection = new SqliteConnection(_connectionString);
			connection.Open();
			var id = connection.Execute(sql, obj);

			return id;
		}

		public static void Delete<T>(CrudObject obj)
		{
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var sql = typeof(T).GetProperty("DeleteSql")?.GetValue(null) as string;
            var id = connection.Execute(sql, obj);
        }

		public static T Get<T>(int id) where T: CrudObject
		{
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var sql = typeof(T).GetProperty("GetSql")?.GetValue(null) as string;
            var obj = connection.QueryFirstOrDefault<T>(sql, new { id });
			return obj;
        }
	}
}

