﻿using IntJob.DataAccess.DbAccess;
using IntJob.DataAccess.Models;
using System;

namespace IntJob.DataAccess.Data
{
    public class IndustryData
    {
        private readonly SqliteDataAccess _db;

        public IndustryData(SqliteDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<IndustryModel>> ListIndustries()
        {
            string sql = @"SELECT * FROM Industry ORDER BY Id DESC";

            return _db.LoadData<IndustryModel, dynamic>(sql, new { });
        }

        public async Task<IndustryModel?> GetIndustry(int id)
        {
            string sql = @"SELECT * FROM Industry WHERE Id = @Id";

            var results = await _db.LoadData<IndustryModel, dynamic>(sql, new { Id = id });

            return results.FirstOrDefault();
        }

        public Task<IndustryModel> CreateIndustry(IndustryModel industry)
        {
            string sql = @"INSERT INTO Industry (Name)
                VALUES (@Name);
                SELECT * FROM Industry WHERE Id = last_insert_rowid();";

            return _db.SaveData<IndustryModel, dynamic>(sql, new{ industry.Name });
        }

        public Task<IndustryModel> UpdateIndustry(IndustryModel industry)
        {
            string sql = @"UPDATE Industry
                SET Name = @Name
                WHERE Id = @Id;
                SELECT * FROM Industry WHERE Id = @Id;";

            return _db.SaveData<IndustryModel, dynamic>(sql, industry);
        }

        public Task<IndustryModel> DeleteIndustry(int id)
        {
            string sql = @"DELETE FROM Industry WHERE Id = @Id;";

            return _db.SaveData<IndustryModel, dynamic>(sql, new { Id = id });
        }
    }
}

