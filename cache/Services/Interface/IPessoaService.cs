using cache.Model;

namespace cache.Services.Interface
{
    public interface IPessoaService
    {
        public PessoaFisica GetByCpf(string cpf);
        public PessoaJuridica GetByCnpj(string cnpj);
    }
}