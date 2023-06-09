﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NewsApiV2.Controllers.Models
{
	
	public class Announcement
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Message { get; set; }
		[Required]
		public string CategoryId { get; set; }
		public string Author { get; set; }
		public string ImageUrl { get; set; }

        public Announcement()
		{
		}
	}
}
