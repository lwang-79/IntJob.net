using IntJob.DataAccess.DbAccess;
using IntJob.DataAccess.Models;
using System;

namespace IntJob.DataAccess.Data
{
    public class HolidayData
    {
        private readonly SqliteDataAccess _db;

        public HolidayData(SqliteDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<HolidayModel>> ListHolidays()
        {
            string sql = @"SELECT * FROM Holiday ORDER BY Id DESC";

            return _db.LoadData<HolidayModel, dynamic>(sql, new { });
        }

        public async Task<HolidayModel?> GetHoliday(int id)
        {
            string sql = @"SELECT * FROM Holiday WHERE Id = @Id";

            var results = await _db.LoadData<HolidayModel, dynamic>(sql, new { Id = id });

            return results.FirstOrDefault();
        }

        public Task<HolidayModel> CreateHoliday(HolidayModel holiday)
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

        public Task<HolidayModel> UpdateHoliday(HolidayModel holiday)
        {
            string sql = @"UPDATE Holiday
                SET Date = @Date, Name = @Name
                WHERE Id = @Id;
                SELECT * FROM Holiday WHERE Id = @Id;";

            return _db.SaveData<HolidayModel, dynamic>(sql, holiday);
        }

        public Task<HolidayModel> DeleteHoliday(int id)
        {
            string sql = @"DELETE FROM Holiday WHERE Id = @Id;";

            return _db.SaveData<HolidayModel, dynamic>(sql, new { Id = id });
        }
    }
}

