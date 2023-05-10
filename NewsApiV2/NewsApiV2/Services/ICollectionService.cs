﻿using System;
namespace NewsApiV2.Services
{
	public interface ICollectionService<T> where T: new()
	{
        Task<List<T>> GetAll();

        Task<T> Get(Guid id);

        Task<bool> Create(T model);

        Task<bool> Update(Guid id, T model);

        Task<List<T>> Delete(Guid id);

    }
}

