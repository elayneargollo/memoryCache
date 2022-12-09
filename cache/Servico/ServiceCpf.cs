using System;
using cache.Integracao;
using cache.Model;
using Microsoft.Extensions.Caching.Memory;

namespace cache.Servico.ServiceCpf
{
    public class ServiceCpf
    {
        public IntegracaoCpf _integracao = new IntegracaoCpf();
        public IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        private const string key = "cpf";
        private const int timeExpiration = 10;
        private const int hoursExpirationRelativeToNow = 1;

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

        private void ValidarDocumento(string cpf)
        {
            if(string.IsNullOrEmpty(cpf) || !Util.ValidarDocumento(cpf))
                throw new System.Exception("Documento inválido");
        }

        private void GravarCache(Pessoa pessoa)
        {        
            Pessoa pessoaCache = _memoryCache.GetOrCreate(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(timeExpiration);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(hoursExpirationRelativeToNow);

                return pessoa;
            });
        }
    }
}