using System;
using cache.Integration;
using cache.Model;
using Microsoft.Extensions.Caching.Memory;

namespace cache.Services.PessoaService
{
    public class PessoaService : IPessoaService
    {
        private readonly IConsultaExterna _consultaExterna;
        public IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());
        private const string Key = "cpf";
        private const int TimeExpiration = 10;
        private const int HoursExpirationRelativeToNow = 1;

        public PessoaService(IConsultaExterna consultaExterna)
        {
            _consultaExterna = consultaExterna;
        }

        public Pessoa GetByCpf(string cpf)
        {
            ValidarDocumento(cpf);

            Pessoa pessoaCache = MemoryCache.Get<Pessoa>(Key);

            if(pessoaCache != null) 
                return pessoaCache;

            Pessoa pessoa = _consultaExterna.GetByCpf(cpf);
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
            Pessoa pessoaCache = MemoryCache.GetOrCreate(Key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(TimeExpiration);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(HoursExpirationRelativeToNow);

                return pessoa;
            });
        }
    }
}