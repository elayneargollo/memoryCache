using cache.Integration;
using cache.Model;
using cache.Services.Interface;
using System;

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

        public PessoaFisica GetByCpf(string cpf)
        {
            ValidarDocumento(cpf);
            PessoaFisica pessoaCache = _memoryCache.ObterPessoaCache<PessoaFisica>();

            if(pessoaCache != null) 
                return pessoaCache;

            PessoaFisica pessoa = _consultaExterna.GetByDocumento<PessoaFisica>(cpf);
            _memoryCache.GravarCache(pessoa);

            return pessoa;
        }

        public PessoaJuridica GetByCnpj(string cnpj)
        {
            ValidarDocumento(cnpj);
            PessoaJuridica pessoaCache = _memoryCache.ObterPessoaCache<PessoaJuridica>();

            if(pessoaCache != null) 
                return pessoaCache;

            PessoaJuridica pessoa = _consultaExterna.GetByDocumento<PessoaJuridica>(cnpj);
            _memoryCache.GravarCache(pessoa);

            return pessoa;
        }

        private void ValidarDocumento(string documento)
        {
            if(string.IsNullOrEmpty(documento) || !Util.ValidarDocumento(documento))
                throw new System.Exception("Documento inválido");
        }
    }
}