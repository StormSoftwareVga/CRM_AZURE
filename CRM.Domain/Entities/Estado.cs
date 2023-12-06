using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Estado : Entity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public Regiao? Regiao { get; set; }
        public Pais Pais { get; set; }
    }
}
