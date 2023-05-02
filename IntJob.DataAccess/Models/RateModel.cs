using System;
namespace IntJob.DataAccess.Models
{
	public class RateModel
	{
        public int Id { get; set; }
        public string Name { get; set; } = "Rate Name";
        public int MinTime { get; set; }
        public float MinTimeRate { get; set; }
        public int EachTime { get; set; }
        public float EachTimeRate { get; set; }
        public int EarlyCancelTime { get; set; }
        public float EarlyCancelRate { get; set; }
        public int LateCancelTime { get; set; }
        public float LateCancelRate { get; set; }
        public int DeductThreshold { get; set; }
        public int DeductTime { get; set; }
        public string Comment { get; set; } = "";
        public int AgentId { get; set; }                    // Forin Key
        public int Type { get; set; }                       // Enum
        public int Category { get; set; }                   // Enum
        public bool Expired { get; set; } = false;
    }
}

