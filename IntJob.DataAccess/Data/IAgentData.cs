using IntJob.DataAccess.Models;

namespace IntJob.DataAccess.Data
{
    public interface IAgentData
    {
        Task CreateAgent(AgentModel agent);
        Task DeleteAgent(int id);
        Task<AgentModel?> GetAgent(int id);
        Task<IEnumerable<AgentModel>> ListAgents();
        Task UpdateAgent(AgentModel agent);
    }
}