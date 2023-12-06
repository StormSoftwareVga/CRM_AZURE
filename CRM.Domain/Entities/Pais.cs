using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Pais : Entity
    {
        public Pais()
        {
            Nome = string.Empty;
        }

        public string Nome { get; set; }
    }
}
