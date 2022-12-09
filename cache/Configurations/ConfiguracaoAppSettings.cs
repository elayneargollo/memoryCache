using System;
using System.Collections.Specialized;
using System.Configuration;

namespace cache.Configurations.ConfiguracaoAppSettings
{
    public static class ConfiguracaoAppSettings
    {
        private static NameValueCollection configuracaoAplicacao = ConfigurationManager
                                    .GetSection("ApplicationSettings")  as NameValueCollection;

        public static string ObterValorChave(string chave)
        {
            foreach (var key in configuracaoAplicacao.AllKeys)
            {
                if(key.Equals(chave))
                    return configuracaoAplicacao[key];
            }

            throw new Exception("A seção ConfiguracaoAplicacao não esta definida");
        }
    }
}