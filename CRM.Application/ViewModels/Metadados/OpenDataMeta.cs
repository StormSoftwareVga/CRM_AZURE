using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Metadados
{
    /// <summary>
    /// Meta informações referentes à API requisitada.
    /// </summary>
    public class OpenDataMeta : Domain.Core.Notifications.Meta
    {
        /// <summary>
        /// Número total de registros no resultado.
        /// </summary>
        /// <example>1</example>
        public int? TotalRecords { get; set; }

        /// <summary>
        /// Número total de páginas no resultado.
        /// </summary>
        /// <example>1</example>
        public int? TotalPages { get; set; }
    }
}
