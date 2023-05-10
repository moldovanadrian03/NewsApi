using System;
using NewsApiV2.Controllers.Models;

namespace NewsApiV2.Services
{
	public interface IAnnouncementCollectionService : ICollectionService<Announcement> 
	{
        Task <List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}

