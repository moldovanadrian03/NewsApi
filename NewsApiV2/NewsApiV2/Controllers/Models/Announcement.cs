using System;
namespace NewsApiV2.Controllers.Models
{
	public class Announcement
	{
		public Guid Id { get; set; }
		string Title { get; set; }
		string Descripiton { get; set; }
		string CategoryId { get; set; }
		string Author { get; set; }

		public Announcement()
		{
		}
	}
}
