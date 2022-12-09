using System;
using System.Collections.Specialized;
using System.Configuration;

namespace cache.Servico.ConfiguracaoAppSettings
{
    public static class ConfiguracaoAppSettings
    {
        private static NameValueCollection applicationSettings = ConfigurationManager
                                    .GetSection("ApplicationSettings")  as NameValueCollection;

        public static string ObterValorChave(string chave)
        {
            foreach (var key in applicationSettings.AllKeys)
            {
                if(key.Equals(chave))
                    return applicationSettings[key];
            }

            throw new Exception("A seção ApplicationSettings não esta definida");
        }
    }
}