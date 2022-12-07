using System;
using cache.Integracao;
using cache.Model;
using Microsoft.Extensions.Caching.Memory;

namespace cache.Servico.ServiceCpf
{
    public class ServiceCpf
    {
        public IntegracaoCpfCnpj _integracao = new IntegracaoCpfCnpj();
        public IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        private const string key = "cpf";

        public Pessoa GetByCpf(string cpf)
        {
            ValidarDocumento(cpf);

            Pessoa pessoaCache = _memoryCache.Get<Pessoa>(key);

            if(pessoaCache != null) 
                return pessoaCache;

            Pessoa pessoa = _integracao.GetByCpf(cpf);
            GravarCache(pessoa);

            return pessoa;
        }

        public void ValidarDocumento(string cpf)
        {
            if(string.IsNullOrEmpty(cpf) || !Util.ValidarDocumento(cpf))
                throw new System.Exception("Documento inválido");
        }

        public void GravarCache(Pessoa pessoa)
        {        
            Pessoa pessoaCache = _memoryCache.GetOrCreate(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(10);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                return pessoa;
            });
        }
    }
}