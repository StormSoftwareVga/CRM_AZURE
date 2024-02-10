using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.Notifications
{
    public class ErrorBase
    {
        public ErrorBase()
        {
            Error = new Error();
        }

        public ErrorBase(string code, string title, string detail)
        {
            var error = new ErrorItem
            {
                Code = code,
                Title = title,
                Detail = detail
            };

            if (Error == null)
                Error = new Error();

            if (Error.Errors == null)
                Error.Errors = new List<ErrorItem>();

            Error.Errors.Add(error);
        }

        /// <summary>
        /// Obejto de Exceção
        /// </summary>
        public Error Error { get; set; }
    }
}
