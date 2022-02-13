using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Data
{
    public class CacheRepositoryDecorator<T> : IRepositorioBase<T> where T : class, new()
    {
        private readonly IRepositorioBase<T> repositorioBase;
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly string _baseCachePrefixKey = $"{typeof(T).Name}:Cache:";

        public CacheRepositoryDecorator(IRepositorioBase<T> repositorioBase)
        {
            this.repositorioBase = repositorioBase;
        }

        public Task<int> AddAsync(T modelToInsert)
        {
            return repositorioBase.AddAsync(modelToInsert);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> cacheValue = _cache.Get(_baseCachePrefixKey) as List<T>;
            if (cacheValue != null)
            {
                return cacheValue;
            }

            List<T> result = await repositorioBase.GetAllAsync();
            _cache.Set(_baseCachePrefixKey, result, DateTimeOffset.Now.AddHours(1));

            return result;
        }

        public Task<T> GetByIdAsync(int id)
        {
            return repositorioBase.GetByIdAsync(id);
        }

        public Task<List<T>> GetMultiIdAsync(List<int> list)
        {
            return repositorioBase.GetMultiIdAsync(list);
        }

        public Task<bool> UpdateAsync(T modelToInsert)
        {
            return repositorioBase.UpdateAsync(modelToInsert);
        }
    }
}
