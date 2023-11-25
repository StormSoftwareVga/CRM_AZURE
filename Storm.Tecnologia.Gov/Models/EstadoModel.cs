using System;
using System.Collections.Generic;
using System.Text;

namespace Storm.Tecnologia.Gov.Models
{
    public class EstadoModel
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public RegiaoEstadoModel regiao { get; set; }
    }
}
