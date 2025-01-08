namespace WebAPI.Models
{
    public class Review
    {
<<<<<<< HEAD
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; } // Navigation property
        public int BarberID { get; set; }
        public Barber Barber { get; set; } // Navigation property
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
=======
        public int Id { get; set; } 

        public int? BarberId { get; set; } 
        public Barber? Barber { get; set; } 

        public int Rating { get; set; }

        public string? Comment { get; set; } 

        public DateTime CreatedAt { get; set; } 
    }
}

>>>>>>> origin/Mobile
