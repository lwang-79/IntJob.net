using System;
namespace IntJob.DataAccess.Models
{
	public class AgentModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = "Agent Name";
		public string? FullName { get; set; }
        public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
		public string? BusinessHourStart { get; set; } = "08:00";
		public string? BusinessHourEnd { get; set; } = "18:00";
	}
}

