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
        public object Dados;

        public object GravarCache(string dadosSerializados)
        {        
            if (!MemoryCache.TryGetValue(Key, out Dados))
            {
                var opcoesDoCache = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(TimeExpiration)
                };

                Dados = dadosSerializados;
                MemoryCache.Set(Key, Dados, opcoesDoCache);
            }

            return Dados;

            // Dados dados = MemoryCache.GetOrCreate(Key, entry =>
            // {
            //     entry.SlidingExpiration = TimeSpan.FromSeconds(TimeExpiration);
            //     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(HoursExpirationRelativeToNow);

            //     return dadosSerializados;
            // });
        }

        public object ObterDadosCache()
        {
            return MemoryCache.Get(Key);
        }
    }
}