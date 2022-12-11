using cache.Model;

namespace cache.Services.Interface
{
    public interface IMemoryCacheService
    {
        public void GravarCache<T>(T pessoa);
        public T ObterPessoaCache<T>();
    }
}