using System;
using System.Collections.Generic;
using System.Text;

namespace Storm.Tecnologia.Gov.Models
{
    public class CnpjModel
    {
        public List<CnpjAtividadeModel> atividade_principal = new List<CnpjAtividadeModel>();

        public List<CnpjAtividadeModel> atividades_secundarias = new List<CnpjAtividadeModel>();

        public List<CnpjQsaModel> qsa = new List<CnpjQsaModel>();

        public string data_situacao { get; set; }

        public string complemento { get; set; }

        public string tipo { get; set; }

        public string nome { get; set; }

        public string telefone { get; set; }

        public string email { get; set; }

        public string situacao { get; set; }

        public string bairro { get; set; }

        public string logradouro { get; set; }

        public string numero { get; set; }

        public string cep { get; set; }

        public string municipio { get; set; }

        public string uf { get; set; }

        public string porte { get; set; }

        public string abertura { get; set; }

        public string natureza_juridica { get; set; }

        public string fantasia { get; set; }

        public string cnpj { get; set; }

        public string ultima_atualizacao { get; set; }

        public string status { get; set; }

        public string efr { get; set; }

        public string motivo_situacao { get; set; }

        public string situacao_especial { get; set; }

        public string data_situacao_especial { get; set; }

        public string capital_social { get; set; }

        public string message { get; set; }
    }
}
