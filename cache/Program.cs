using System;
using cache.Model;
using cache.Sccoped;
using cache.Services.Interface;
using Newtonsoft.Json;

namespace cache
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantidadeMaxConsulta = 5;

            for (int contador = 0; contador <= quantidadeMaxConsulta; contador++)
            {
                Console.WriteLine("Informe o cpf/cnpj: ");
                string documento = Console.ReadLine();

                ConsultarDocumento(documento);
            }
        }

        static void ConsultarDocumento(string documento)
        {
            IPessoaService _pessoaService = ServiceProvide.ObterInjecaoServicoCpf();

            if(documento.Length <= 11)
            {
                PessoaFisica pessoaFisica = _pessoaService.GetByCpf(documento);
                Console.WriteLine(JsonConvert.SerializeObject(pessoaFisica));
            }

            PessoaJuridica pessoaJuridica = _pessoaService.GetByCnpj(documento);
            Console.WriteLine(JsonConvert.SerializeObject(pessoaJuridica));
        }
    }
}
