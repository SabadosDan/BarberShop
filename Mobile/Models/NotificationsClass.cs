using Plugin.LocalNotification;


namespace Mobile.Models
{
    public class NotificationsClass
    {
        public void ScheduleNotification(DateTime appointmentDateTime)
        {
            // Calculăm cu o zi înainte de programare
            DateTime notificationDateTime = appointmentDateTime.AddDays(-1);

            

            if (notificationDateTime > DateTime.Now)
            {
                var notification = new NotificationRequest
                {
                    NotificationId = 1,
                    Title = "Reminder: Appointment",
                    Description = "You have an appointment tomorrow!",
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
