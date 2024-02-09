using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Papel : Entity
    {
        public string Nome { get; set; }

        public string Json { get; set; }

        public virtual List<PapelComponente> PapelComponentes { get; set; } = new List<PapelComponente>();

        public virtual List<Papel> Papeis { get; set; } = new List<Papel>();





    }
}

