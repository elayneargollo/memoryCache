using cache.Model;

namespace cache.Services.Interface
{
    public interface IPessoaService
    {
        public string GetByDocumento(string documento);
    }
}