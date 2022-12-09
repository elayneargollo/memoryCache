using cache.Integration;
using cache.Model;
using cache.Services.Interface;

namespace cache.Services.PessoaService
{
    public class PessoaService : IPessoaService
    {
        private readonly IConsultaExterna _consultaExterna;
        private readonly IMemoryCacheService _memoryCache;

        public PessoaService(IConsultaExterna consultaExterna, IMemoryCacheService memoryCache)
        {
            _consultaExterna = consultaExterna;
            _memoryCache = memoryCache;
        }

        public Pessoa GetByCpf(string cpf)
        {
            ValidarDocumento(cpf);
            Pessoa pessoaCache = _memoryCache.ObterPessoaCache();

            if(pessoaCache != null) 
                return pessoaCache;

            Pessoa pessoa = _consultaExterna.GetByCpf(cpf);
            _memoryCache.GravarCache(pessoa);

            return pessoa;
        }

        private void ValidarDocumento(string cpf)
        {
            if(string.IsNullOrEmpty(cpf) || !Util.ValidarDocumento(cpf))
                throw new System.Exception("Documento inválido");
        }
    }
}