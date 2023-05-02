using System;
namespace IntJob.DataAccess.Models
{
	public class HolidayModel
	{
        public int Id { get; set; }
        public string Date { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");
        public string Name { get; set; } = "Holiday Name";
    }
}

