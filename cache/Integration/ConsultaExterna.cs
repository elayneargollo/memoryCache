using System;
using System.Net.Http;
using System.Net.Http.Headers;
using cache.Configurations.ConfiguracaoAppSettings;
using cache.Model;

namespace cache.Integration
{
    public class ConsultaExterna : IConsultaExterna
    {
        protected string Path = ConfiguracaoAppSettings.ObterValorChave("URL_Integracao");
        protected string Token = ConfiguracaoAppSettings.ObterValorChave("Token");
        protected string Pacote = ConfiguracaoAppSettings.ObterValorChave("Pacote");
        protected HttpClient Client = new HttpClient();
        protected string Separador = "/";
        private string Url => String.Concat(Path, Token, Separador, Pacote);  
        private string urlCompleta(string documento) => String.Concat(Url, Separador, documento);

        private void MontarClient(string documento)
        {
            if(Client.BaseAddress != null)
                return;

            Client.BaseAddress = new Uri(urlCompleta(documento));
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Pessoa GetByCpf(string documento)
        {
            try
            {
                MontarClient(documento);

                HttpResponseMessage response = Client.GetAsync(urlCompleta(documento)).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Pessoa>().Result;
                }

                Error erro = response.Content.ReadAsAsync<Error>().Result;
                throw new Exception($"{erro.Erro}");
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Ocorreu um erro !");
                Console.WriteLine($"{exception.Message}");
                throw;
            }
        }
    }
}