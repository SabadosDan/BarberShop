using Plugin.LocalNotification;


namespace Mobile.Models
{
    public class NotificationsClass
    {
        public void ScheduleNotification(DateTime appointmentDateTime)
        {
            
            DateTime notificationDateTime = appointmentDateTime.AddDays(-1);

            if (notificationDateTime > DateTime.Now)
            {
                var notification = new NotificationRequest
                {
                    NotificationId = 1,
                    Title = "Reminder: Barbershop D&A",
                    Description = "Salutare, nu uita ca maine ai o programare la noi la salon," +
                    "Te asteptam cu drag!",
                    BadgeNumber=42,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = notificationDateTime,
                        NotifyRepeatInterval = TimeSpan.FromDays(1),
                    },
                };
                LocalNotificationCenter.Current.Show(notification);
            }
        }
    }
}
