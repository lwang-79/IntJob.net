using IntJob.DataAccess.DbAccess;
using IntJob.DataAccess.Models;
using System;

namespace IntJob.DataAccess.Data
{
    public class RateData
    {
        private readonly SqliteDataAccess _db;

        public RateData(SqliteDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<RateModel>> ListRates()
        {
            string sql = @"SELECT * FROM Rate ORDER BY Id DESC";

            return _db.LoadData<RateModel, dynamic>(sql, new { });
        }

        public async Task<RateModel?> GetRate(int id)
        {
            string sql = @"SELECT * FROM Rate WHERE Id = @Id";

            var results = await _db.LoadData<RateModel, dynamic>(sql, new { Id = id });

            return results.FirstOrDefault();
        }

        public Task<RateModel> CreateRate(RateModel rate)
        {
            string sql = @"INSERT INTO Rate (Name, MinTime, MinTimeRate, EachTime, 
                EachTimeRate, EarlyCancelTime, EarlyCancelRate, LateCancelTime, 
                LateCancelRate, DeductThreshold, DeductTime, Comment, AgentId, 
                Type, Category, Expired)
                VALUES (@Name, @MinTime, @MinTimeRate, @EachTime, @EachTimeRate,
                @EarlyCancelTime, @EarlyCancelRate, @LateCancelTime, 
                @LateCancelRate, @DeductThreshold, @DeductTime, @Comment, @AgentId, 
                @Type, @Category, @Expired);
                SELECT * FROM Rate WHERE Id = last_insert_rowid();";

            return _db.SaveData<RateModel, dynamic>(sql, new
            {
                rate.Name,
                rate.MinTime,
                rate.MinTimeRate,
                rate.EachTime,
                rate.EachTimeRate,
                rate.EarlyCancelTime,
                rate.EarlyCancelRate,
                rate.LateCancelTime,
                rate.LateCancelRate,
                rate.DeductThreshold,
                rate.DeductTime,
                rate.Comment,
                rate.AgentId,
                rate.Type,
                rate.Category,
                rate.Expired
            });
        }

        public Task<RateModel> UpdateRate(RateModel rate)
        {
            string sql = @"UPDATE Rate
                SET Name = @Name, MinTime = @MinTime, MinTimeRate = @MinTimeRate,
                    EachTime = @EachTime, EachTimeRate = @EachTimeRate,
                    EarlyCancelTime = @EarlyCancelTime, EarlyCancelRate = @EarlyCancelRate,
                    LateCancelTime = @LateCancelTime, LateCancelRate = @LateCancelRate,
                    DeductThreshold = @DeductThreshold, DeductTime = @DeductTime,
                    Comment = @Comment, AgentId = @AgentId, Type = @Type,
                    Category = @Category, Expired = @Expired
                WHERE Id = @Id;
                SELECT * FROM Rate WHERE Id = @Id;";

            return _db.SaveData<RateModel, dynamic>(sql, rate);
        }

        public Task<RateModel> DeleteRate(int id)
        {
            string sql = @"DELETE FROM Rate WHERE Id = @Id;";

            return _db.SaveData<RateModel, dynamic>(sql, new { Id = id });
        }
    }
}

