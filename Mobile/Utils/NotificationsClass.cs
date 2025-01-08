using Plugin.LocalNotification;


namespace Mobile.Utils
{
    public class NotificationsClass
    {
        public void ScheduleNotification(DateTime appointmentDateTime)
        {

            DateTime notificationDateTime = appointmentDateTime.AddSeconds(5);

            if (notificationDateTime > DateTime.Now)
            {
                var notification = new NotificationRequest
                {
                    NotificationId = 1,
                    Title = "Reminder: Barbershop D&A",
                    Description = "Salutare, nu uita ca maine ai o programare la noi la salon," +
                    "Te asteptam cu drag!",
                    BadgeNumber = 42,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddSeconds(5),
                        NotifyRepeatInterval = TimeSpan.FromDays(1),
                    },
                };
                LocalNotificationCenter.Current.Show(notification);
            }
        }
    }
}
