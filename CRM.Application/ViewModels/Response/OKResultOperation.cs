using CRM.Application.ViewModels.Metadados;
using CRM.Application.ViewModels.Paginacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Response
{
    public class OKResultOperation<T>
    {
        public OKResultOperation()
        {
            Data = default(T);
        }

        public OKResultOperation(T data)
        {
            Data = data;
        }

        #region Propriedades

        /// <summary>
        /// Objeto de Retorno
        /// </summary>
        public T Data { get; set; }

        public Domain.Core.Notifications.Meta Meta { get; set; } = new Domain.Core.Notifications.Meta();

        public Links? Links { get; set; }

        #endregion
    }
}
