using System;
using cache.Model;
using cache.Sccoped;
using cache.Services;
using Newtonsoft.Json;

namespace cache
{
    class Program
    {
        static void Main(string[] args)
        {
            IPessoaService _servicoCpf = ServiceProvide.ObterInjecaoServicoCpf();
            int quantidadeMaxConsulta = 5;

            for (int contador = 0; contador <= quantidadeMaxConsulta; contador++)
            {
                Console.WriteLine("Informe o cpf: ");
                string cpf = Console.ReadLine();

                Pessoa pessoa = _servicoCpf.GetByCpf(cpf);
                Console.WriteLine(JsonConvert.SerializeObject(pessoa));
            }
        }
    }
}
