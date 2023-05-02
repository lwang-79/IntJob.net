using IntJob.DataAccess.DbAccess;
using IntJob.DataAccess.Models;
using System;

namespace IntJob.DataAccess.Data
{
    public class HolidayData : IModelData<HolidayModel>
    {
        private readonly SqliteDataAccess _db;

        public HolidayData(SqliteDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<HolidayModel>> List()
        {
            string sql = @"SELECT * FROM Holiday ORDER BY Id DESC";

            return _db.LoadData<HolidayModel, dynamic>(sql, new { });
        }

        public async Task<HolidayModel?> Get(int id)
        {
            string sql = @"SELECT * FROM Holiday WHERE Id = @Id";

            var results = await _db.LoadData<HolidayModel, dynamic>(sql, new { Id = id });

            return results.FirstOrDefault();
        }

        public Task<HolidayModel> Create(HolidayModel holiday)
        {
            string sql = @"INSERT INTO Holiday (Date, Name)
                VALUES (@Date, @Name);
                SELECT * FROM Holiday WHERE Id = last_insert_rowid();";

            return _db.SaveData<HolidayModel, dynamic>(sql, new
            {
                holiday.Date,
                holiday.Name,
            });
        }

        public Task<HolidayModel> Update(HolidayModel holiday)
        {
            string sql = @"UPDATE Holiday
                SET Date = @Date, Name = @Name
                WHERE Id = @Id;
                SELECT * FROM Holiday WHERE Id = @Id;";

            return _db.SaveData<HolidayModel, dynamic>(sql, holiday);
        }

        public Task<HolidayModel> Delete(int id)
        {
            string sql = @"DELETE FROM Holiday WHERE Id = @Id;";

            return _db.SaveData<HolidayModel, dynamic>(sql, new { Id = id });
        }
    }
}

