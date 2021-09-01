using System.Collections.Generic;
using DevCA.Business.Notifications;

namespace DevCA.Business.Interfaces
{
    public interface INotificator
    {
        bool ThereIsNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notificator);
    }
}