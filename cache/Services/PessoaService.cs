using cache.Integration;
using cache.Model;
using cache.Services.Interface;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

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

        public string GetByDocumento(string documento)
        {
            ValidarDocumento(documento);
            string dadosCache = _memoryCache.ObterDadosCache<string>();

            if(dadosCache != null) 
                return JsonConvert.SerializeObject(dadosCache);
            
            dynamic dados = _consultaExterna.GetByDocumento<dynamic>(documento);
            string dadosSerializados = JsonConvert.SerializeObject(dados);

            _memoryCache.GravarCache(dadosSerializados);
            return dadosSerializados;
        }

        private void ValidarDocumento(string documento)
        {
            if(string.IsNullOrEmpty(documento) || !Util.ValidarDocumento(documento))
                throw new System.Exception("Documento inválido");
        }
    }
}