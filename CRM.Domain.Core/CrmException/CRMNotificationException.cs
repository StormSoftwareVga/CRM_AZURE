using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.CrmException
{
    public class CRMNotificationException : Exception
    {
        public CRMNotificationException()
        {
        }

        public CRMNotificationException(string mensagem) : base(mensagem)
        { 
        }

        public CRMNotificationException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {
        }
    }
}
