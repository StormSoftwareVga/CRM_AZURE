using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class PessoaEndereco : Entity
    {
        public Pessoa Pessoa { get; set; }
        public string CEP { get; set; }
        public Pais Pais { get; set; }
        public Estado Estado { get; set; }
        public Municipio Municipio { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

    }
}
