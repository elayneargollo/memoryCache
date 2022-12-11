using cache.Model;

namespace cache.Services.Interface
{
    public interface IMemoryCacheService
    {
        public object GravarCache(string dadosSerializados);
        public object ObterDadosCache();
    }
}