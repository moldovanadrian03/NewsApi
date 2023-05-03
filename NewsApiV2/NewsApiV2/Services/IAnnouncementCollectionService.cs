using System;
using NewsApiV2.Controllers.Models;

namespace NewsApiV2.Services
{
	public interface IAnnouncementCollectionService : ICollectionService<Announcement> 
	{
        List<Announcement> GetAnnouncementsByCategoryId(string categoryId);
    }
}

