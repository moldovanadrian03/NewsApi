using System;
namespace NewsApiV2.Services
{
	public interface ICollectionService<T> where T: 
	{
        List<T> GetAll();

        T Get(Guid id);

        bool Create(T model);

        bool Update(Guid id, T model);

        bool Delete(Guid id);

    }
}

