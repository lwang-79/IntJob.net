using System;
using Microsoft.Extensions.Configuration;
using Utils.Log;
using IntJob.DataAccess.Data;
using IntJob.DataAccess.Models;
using IntJob.DataAccess.DbAccess;

namespace IntJob.Maui
{
	public class DataStore
	{
        private AgentData _agentData;
        private HolidayData _holidayData;
        private IndustryData _industryData;
        private JobData _jobData;
        private RateData _rateData;

        public DataStore(IConfiguration config)
		{
            SqliteDataAccess sqliteDataAccess = new SqliteDataAccess(config);
            _agentData = new AgentData(sqliteDataAccess);
            _holidayData = new HolidayData(sqliteDataAccess);
            _industryData = new IndustryData(sqliteDataAccess);
            _jobData = new JobData(sqliteDataAccess);
            _rateData = new RateData(sqliteDataAccess);
        }

        public async Task<AgentModel> GetAgent(int id)
        {
            try
            {
                return await _agentData.GetAgent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to get agent: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<AgentModel>> ListAgents()
        {
            try
            {
                return await _agentData.ListAgents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to list agents: {ex.Message}");
                return new List<AgentModel>();
            }
        }

        public async Task<AgentModel> CreateAgent(AgentModel agent)
        {
            try
            {
                return await _agentData.CreateAgent(agent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to create agent: {ex.Message}");
                return null;
            }
        }

        public async Task<AgentModel> UpdateAgent(AgentModel agent)
        {
            try
            {
                return await _agentData.UpdateAgent(agent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to update agent: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteAgent(int id)
        {
            try
            {
                await _agentData.DeleteAgent(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to delete agent: {ex.Message}");
                return false;
            }
        }

        public async Task<HolidayModel> GetHoliday(int id)
        {
            try
            {
                return await _holidayData.GetHoliday(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to get holiday: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<HolidayModel>> ListHolidays()
        {
            try
            {
                return await _holidayData.ListHolidays();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to list holidays: {ex.Message}");
                return new List<HolidayModel>();
            }
        }

        public async Task<HolidayModel> CreateHoliday(HolidayModel holiday)
        {
            try
            {
                return await _holidayData.CreateHoliday(holiday);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to create holiday: {ex.Message}");
                return null;
            }
        }

        public async Task<HolidayModel> UpdateHoliday(HolidayModel holiday)
        {
            try
            {
                return await _holidayData.UpdateHoliday(holiday);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to update holiday: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteHoliday(int id)
        {
            try
            {
                await _holidayData.DeleteHoliday(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to delete holiday: {ex.Message}");
                return false;
            }
        }
    }

    
}

