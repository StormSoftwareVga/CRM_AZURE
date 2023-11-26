using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Regiao : Entity
    {
        public Regiao()
        {
            Nome = string.Empty;
            Sigla = string.Empty;
        }

        public Pais Pais { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
