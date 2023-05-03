using System;
using NewsApiV2.Controllers.Models;

namespace NewsApiV2.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        List<Announcement> _announcements = new List<Announcement> {
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "First Announcement", Description = "First Announcement Description" , Author = "Author_1"},
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Second Announcement", Description = "Second Announcement Description", Author = "Author_1" },
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Third Announcement", Description = "Third Announcement Description", Author = "Author_2"  },
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fourth Announcement", Description = "Fourth Announcement Description", Author = "Author_3"  },
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fifth Announcement", Description = "Fifth Announcement Description", Author = "Author_4"  }
        };

        public List<Announcement> GetAll()
        {
            return _announcements;
        }

        public Announcement Get(Guid id)
        {
            return _announcements.Where(ann => ann.Id == id).SingleOrDefault();
        }

        public List<Announcement> GetAnnouncementsByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Announcement> Create(Announcement model)
        {
            _announcements.Add(model);
            return _announcements;
        }

        public bool Update(Guid id, Announcement model)
        {
            return true;
        }

        public List<Announcement> Delete(Guid id)
        {
            _announcements.RemoveAll(ann => ann.Id == id);
            return _announcements;
        }

    }
}

