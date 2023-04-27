﻿using System;
namespace NewsApiV2.Controllers.Models
{
	public class Announcement
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string CategoryId { get; set; }
		public string Author { get; set; }

        public Announcement()
		{
		}
	}
}
