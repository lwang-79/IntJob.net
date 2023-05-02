using IntJob.DataAccess.DbAccess;
using IntJob.DataAccess.Models;
using System;

namespace IntJob.DataAccess.Data
{
    public class AgentData : IModelData<AgentModel>
    {
        private readonly SqliteDataAccess _db;

        public AgentData(SqliteDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<AgentModel>> List()
        {
            string sql = @"SELECT * FROM Agent ORDER BY Id DESC";

            return _db.LoadData<AgentModel, dynamic>(sql, new { });
        }

        public async Task<AgentModel?> Get(int id)
        {
            string sql = @"SELECT * FROM Agent WHERE Id = @Id";

            var results = await _db.LoadData<AgentModel, dynamic>(sql, new { Id = id });

            return results.FirstOrDefault();
        }

        public Task<AgentModel> Create(AgentModel agent)
        {
            string sql = @"INSERT INTO Agent (Name, FullName, Address, PhoneNumber, Email, BusinessHourStart, BusinessHourEnd)
                VALUES (@Name, @FullName, @Address, @PhoneNumber, @Email, @BusinessHourStart, @BusinessHourEnd);
                SELECT * FROM Agent WHERE Id = last_insert_rowid();";

            return _db.SaveData<AgentModel, dynamic>(sql, new
            {
                agent.Name,
                agent.FullName,
                agent.Address,
                agent.PhoneNumber,
                agent.Email,
                agent.BusinessHourStart,
                agent.BusinessHourEnd
            });
        }

        public Task<AgentModel> Update(AgentModel agent)
        {
            string sql = @"UPDATE Agent
                SET Name = @Name, FullName = @FullName, Address = @Address,
                    PhoneNumber = @PhoneNumber, Email = @Email,
                    BusinessHourStart = @BusinessHourStart, BusinessHourEnd = @BusinessHourEnd
                WHERE Id = @Id;
                SELECT * FROM Agent WHERE Id = @Id;";

            return _db.SaveData<AgentModel, dynamic>(sql, agent);
        }

        public Task<AgentModel> Delete(int id)
        {
            string sql = @"DELETE FROM Agent WHERE Id = @Id;";

            return _db.SaveData<AgentModel, dynamic>(sql, new { Id = id });
        }
    }
}

