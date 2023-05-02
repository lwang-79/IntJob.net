using IntJob.DataAccess.DbAccess;
using IntJob.DataAccess.Models;
using System;

namespace IntJob.DataAccess.Data
{
    public class JobData
    {
        private readonly SqliteDataAccess _db;

        public JobData(SqliteDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<JobModel>> ListJobs()
        {
            string sql = @"SELECT * FROM Job ORDER BY Id DESC";

            return _db.LoadData<JobModel, dynamic>(sql, new { });
        }

        public async Task<JobModel?> GetJob(int id)
        {
            string sql = @"SELECT * FROM Job WHERE Id = @Id";

            var results = await _db.LoadData<JobModel, dynamic>(sql, new { Id = id });

            return results.FirstOrDefault();
        }

        public Task<JobModel> CreateJob(JobModel job)
        {
            string sql = @"INSERT INTO Job (AgentJobNumber, StartAt, Duration,
                    Income, AgentId, IndustryId, CancelAt, Comment, Status, RateId)
                VALUES (@AgentJobNumber, @StartAt, @Duration, @Income, @AgentId,
                    @IndustryId, @CancelAt, @Comment, @Status, @RateId);
                SELECT * FROM Job WHERE Id = last_insert_rowid();";

            return _db.SaveData<JobModel, dynamic>(sql, new {
                job.AgentJobNumber,
                job.StartAt,
                job.Duration,
                job.Income,
                job.AgentId,
                job.IndustryId,
                job.CancelAt,
                job.Comment,
                job.Status,
                job.RateId
            });
        }

        public Task<JobModel> UpdateJob(JobModel job)
        {
            string sql = @"UPDATE Job
                SET AgentJobNumber = @AgentJobNumber, StartAt = @StartAt,
                    Duration = @Duration, Income = @Income, AgentId = @AgentId,
                    IndustryId = @IndustryId, CancelAt = @CancelId,
                    Comment = @Comment, Status = @Status, RateId = @RatedId
                WHERE Id = @Id;
                SELECT * FROM Job WHERE Id = @Id;";

            return _db.SaveData<JobModel, dynamic>(sql, job);
        }

        public Task<JobModel> DeleteJob(int id)
        {
            string sql = @"DELETE FROM Job WHERE Id = @Id;";

            return _db.SaveData<JobModel, dynamic>(sql, new { Id = id });
        }
    }
}

