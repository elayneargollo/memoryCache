using cache.Model;

namespace cache.Services.Interface
{
    public interface IMemoryCacheService
    {
        public void GravarCache(Pessoa pessoa);
        public Pessoa ObterPessoaCache();
    }
}