using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Componente : Entity
    {
        public string Nome { get; set; }
        public string JsonCampos { get; set; }
        public Guid Hash { get; set; }

        public virtual List<ComponenteEndPoint> ComponenteEndPoints { get; set; } = new List<ComponenteEndPoint>();

        public virtual ICollection<Componente> Componentes { get; set; } = new List<Componente>();
    }
}
