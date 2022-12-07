using System;
using cache.Model;
using cache.Servico.ServiceCpf;
using Newtonsoft.Json;

namespace cache
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCpf servico = new ServiceCpf();
            int quantidadeMaxConsulta = 5;

            for (int contador = 0; contador <= quantidadeMaxConsulta; contador++)
            {
                Console.WriteLine("Informe o cpf: ");
                string cpf = Console.ReadLine();

                Pessoa pessoa = servico.GetByCpf(cpf);
                Console.WriteLine(JsonConvert.SerializeObject(pessoa));
            }
        }
    }
}
