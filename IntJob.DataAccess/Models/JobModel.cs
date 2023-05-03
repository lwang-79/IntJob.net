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

		public static float EstimateIncome(int duration, RateModel rate)
		{
			return duration <= rate.MinTime ? rate.MinTimeRate :
				(float)Math.Round((double)((duration - rate.MinTime) / rate.EachTime))
					* rate.EachTimeRate + rate.MinTimeRate;
		}

		public float CalculateIncome(RateModel rate)
		{
			float income = 0;

			if (Duration <= rate.MinTime)
			{
				income = rate.MinTimeRate;
			}
			else if (Duration >= rate.DeductThreshold)
			{
				int duration = Duration - rate.DeductTime;
				income = (float)Math.Round((double)((duration - rate.MinTime) / rate.EachTime))
                    * rate.EachTimeRate + rate.MinTimeRate;
            }
			else
			{
                income = (float)Math.Round((double)((Duration - rate.MinTime) / rate.EachTime))
                    * rate.EachTimeRate + rate.MinTimeRate;
            }

			if (Status == (int)JobStatus.Canceled && CancelAt != null)
			{
                DateTimeOffset startAt = DateTimeOffset.Parse(StartAt);
                DateTimeOffset cancelAt = DateTimeOffset.Parse(CancelAt);
                TimeSpan gap = startAt - cancelAt;
                int gapInMinutes = (int)gap.TotalMinutes;

				if (gapInMinutes < rate.LateCancelTime)
				{
					income *= rate.LateCancelRate;
				} else if (gapInMinutes < rate.EarlyCancelTime)
				{
					income *= rate.EarlyCancelRate;
				} else
				{
					income = 0;
				}
            }

			Income = (float)Math.Round((double)income, 2);

			return Income;
		}
    }
}

