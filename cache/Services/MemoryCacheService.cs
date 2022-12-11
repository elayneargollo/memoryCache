using System;
using cache.Model;
using cache.Services.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace cache.Services
{
    public class MemoryCacheService : IMemoryCacheService
    {
        public IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());
        private const string Key = "dados";
        private const int TimeExpiration = 10;
        private const int HoursExpirationRelativeToNow = 1;

        public void GravarCache<T>(T dadosSerializados)
        {        
            T dados = MemoryCache.GetOrCreate(Key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(TimeExpiration);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(HoursExpirationRelativeToNow);

                return dadosSerializados;
            });
        }

        public T ObterDadosCache<T>()
        {
            return MemoryCache.Get<T>(Key);
        }
    }
}