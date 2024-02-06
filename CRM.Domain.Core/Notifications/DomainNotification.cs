using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.Notifications
{
    public class DomainNotification
    {
        public KeyNotification Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(KeyNotification key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
