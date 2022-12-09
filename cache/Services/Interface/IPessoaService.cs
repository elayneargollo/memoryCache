using cache.Model;

namespace cache.Services.Interface
{
    public interface IPessoaService
    {
        public Pessoa GetByCpf(string cpf);
    }
}