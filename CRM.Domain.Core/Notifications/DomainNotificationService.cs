using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.Notifications
{
    public interface IDomainNotificationService
    {
       void AddNotification(KeyNotification key, string valor);
        void AddNotificationFalhaProcessamento(string valor);
        List<DomainNotification> GetNotifications();
        bool HasNotifications();
    }
    public class DomainNotificationService : IDomainNotificationService
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationService()
        {
            _notifications = new List<DomainNotification>();
        }

        public void AddNotificationFalhaProcessamento(string valor)
        {
            AddNotification(KeyNotification.FALHA_PROCESSAMENTO, valor);
        }
        public void AddNotification(KeyNotification key, string valor)
        {
            _notifications.Add(new DomainNotification(key, valor)); 
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Count > 0;
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
