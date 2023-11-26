using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Municipio : Entity
    {
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}
