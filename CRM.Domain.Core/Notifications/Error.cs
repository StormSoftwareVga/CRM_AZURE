using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.Notifications
{
    /// <summary>
    /// Representa a lista de erros.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Lista de erros.
        /// </summary>
        public List<ErrorItem> Errors { get; set; } = new List<ErrorItem>();

        /// <summary>
        /// Meta informações referente à API requisitada.
        /// </summary>
        public Meta Meta { get; set; } = new Meta();
    }
}
