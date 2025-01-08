namespace WebAPI.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public int BarberID { get; set; }
        public Barber Barber { get; set; } // Navigation property
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
