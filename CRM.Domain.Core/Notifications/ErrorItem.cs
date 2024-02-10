using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.Notifications
{
    /// <summary>
    /// Representa um item de erro.
    /// </summary>
    public class ErrorItem
    {
        /// <summary>
        /// Código de erro específico do endpoint.
        /// </summary>
        /// <example>string</example>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Título legível por humanos deste erro específico.
        /// </summary>
        /// <example>string</example>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descrição legível por humanos deste erro específico.
        /// </summary>
        /// <example>string</example>
        public string Detail { get; set; } = string.Empty;
    }
}
