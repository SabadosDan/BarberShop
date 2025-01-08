namespace WebAPI.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; } // Navigation property
        public int BarberID { get; set; }
        public Barber Barber { get; set; } // Navigation property
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
