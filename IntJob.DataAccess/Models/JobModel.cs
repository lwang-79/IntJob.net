using System;
namespace IntJob.DataAccess.Models
{
	public class JobModel
	{
		public int Id { get; set; }
		public string AgentJobNumber { get; set; } = "";
		public string StartAt { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
		public int Duration { get; set; }
		public float Income { get; set; }
		public int AgentId { get; set; }		// Forin Key
		public int IndustryId { get; set; }		// Forin Key
        public string? CancelAt { get; set; }
		public string Comment { get; set; } = "";
		public int Status { get; set; }			// Enum
		public int RateId { get; set; }			// Forin Key
    }
}

