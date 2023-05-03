using System;
namespace IntJob.DataAccess.Models
{
	enum JobType
	{
		BH = 1,
		ABH,
		SAT,
		SUN,
		PH
	}

	enum JobCategory
	{
		Telephone = 1,
		OnSite,
		Video,
		Others
	}

	enum JobStatus
	{
		Booked = 1,
		Canceled,
		Completed
	}
}

