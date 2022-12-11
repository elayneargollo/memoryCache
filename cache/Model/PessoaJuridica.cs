using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cache.Model
{
    public class PessoaJuridica
    {
        public string Cnpj { get; set; }
        public string Razao { get; set; }
        public string Fantasia { get; set; }
        public string InicioAtividade { get; set; }
        public string Email { get; set; }
        public string Responsavel { get; set; }
        public MatrizEndereco MatrizEndereco { get; set; }
    }

    public class MatrizEndereco
    {
        public string Cep { get; set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}