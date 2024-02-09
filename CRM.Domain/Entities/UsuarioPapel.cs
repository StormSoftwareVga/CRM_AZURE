using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class UsuarioPapel : Entity
    {
        public Guid PapelID { get; set; }

        public Guid UsuarioID { get; set; }
        public virtual Papel Papel { get; set; }
        public virtual Usuario Usuario{get; set; }
    }
}
