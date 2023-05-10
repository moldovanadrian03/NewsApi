using System;
using MongoDB.Driver;
using NewsApiV2.Controllers.Models;
using NewsApiV2.Settings;

namespace NewsApiV2.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }

        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true);
            return result.ToList();
        }


        //public Announcement Get(Guid id)
        //{
        //    return _announcements.Where(ann => ann.Id == id).SingleOrDefault();
        //}

        //public List<Announcement> GetAnnouncementsByCategoryId(string categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> Create(Announcement announcement)
        {
            if (announcement.Id == Guid.Empty)
            {
                announcement.Id = Guid.NewGuid();
            }

            await _announcements.InsertOneAsync(announcement);
            return true;
        }


        //public bool Update(Guid id, Announcement model)
        //{
        //    return true;
        //}

        //public List<Announcement> Delete(Guid id)
        //{
        //    _announcements.RemoveAll(ann => ann.Id == id);
        //    return _announcements;
        //}

    }
}

