using System;
using System.Net.Http;
using System.Net.Http.Headers;
using cache.Model;

namespace cache.Integracao
{
    public class IntegracaoCpfCnpj
    {
        protected string URL = "https://api.cpfcnpj.com.br/";
        protected string Token = "5ae973d7a997af13f0aaf2bf60e65803";
        protected int Pacote = 9;
        protected string Separador = "/";
        protected HttpClient Client = new HttpClient();
        private string urlCompleta;

        private void MontarClient(string cpfcnpj)
        {
            if(Client.BaseAddress != null)
                return;

            urlCompleta = String.Concat(ObterUrl(), Separador, cpfcnpj);

            Client.BaseAddress = new Uri(urlCompleta);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string ObterUrl()
        {
            return String.Concat(URL, Token, Separador, Pacote);
        }

        public Pessoa GetByCpf(string cpfcnpj)
        {
            try
            {
                MontarClient(cpfcnpj);

                HttpResponseMessage response = Client.GetAsync(urlCompleta).Result;

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