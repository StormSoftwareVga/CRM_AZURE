using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class ComponenteEndPoint : Entity
    {
        public Guid ComponenteID { get; set; }
       
        public string EndPoint { get; set; }

        public virtual Componente Componente { get; set; }
    }
}
