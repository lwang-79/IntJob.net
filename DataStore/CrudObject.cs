namespace DataStore
{
	public abstract class CrudObject
	{
		public int Id = 0;
		public string CreateSql = "";
		public string UpdateSql = "";
		public string DeleteSql = "";
		public string GetSql = "";
		public string ListSql = "";
	}
}

