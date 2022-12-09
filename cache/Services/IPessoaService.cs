using cache.Model;

namespace cache.Services
{
    public interface IPessoaService
    {
        public Pessoa GetByCpf(string cpf);
    }
}