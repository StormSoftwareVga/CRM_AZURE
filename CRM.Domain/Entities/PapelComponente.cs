using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class PapelComponente : Entity
    {

        public Guid PapelID { get; set; }
        public Guid ComponenteID { get; set; }
        public virtual Papel Papel { get; set; }
        public virtual Componente Componente { get; set; }

        
    }
}
