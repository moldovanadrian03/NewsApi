using System;
namespace NewsApiV2.Services
{
	public interface ICollectionService<T> where T: new()
	{
        List<T> GetAll();

        T Get(Guid id);

        List<T> Create(T model);

        bool Update(Guid id, T model);

        List<T> Delete(Guid id);

    }
}

