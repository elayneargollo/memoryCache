using cache.Model;

namespace cache.Services.Interface
{
    public interface IMemoryCacheService
    {
        public void GravarCache<T>(T dadosSerializados);
        public T ObterDadosCache<T>();
    }
}