using CRM.Domain.Core.CrmException;
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
        public Error(string code, string title, string? detail)
        {
            var error = new ErrorItem
            {
                Code = code,
                Title = title,
                Detail = string.IsNullOrEmpty(detail) ? title : detail
            };

            Errors.Add(error);
        }

        public Error(List<ErrorItem> errors)
        {
            foreach (var error in errors) 
                Errors.Add(error);

            if (!(Errors.Count > 0))
                throw new PortalHttpException("Não foi possivel rastrear o erro ocorrido.");
        }


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
