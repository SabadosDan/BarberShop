using WebAPI.Models;

namespace WebAPI.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; } // Navigation property
        public int BarberID { get; set; }
        public Barber Barber { get; set; } // Navigation property
        public int ServiceID { get; set; }
        public Service Service { get; set; } // Navigation property
    }
}
