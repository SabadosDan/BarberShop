<<<<<<< HEAD
﻿using WebAPI.Models;

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
=======
﻿namespace WebAPI.Models
{   
        public class Appointment
        {
            public int Id { get; set; }

            public DateTime DateTime { get; set; }


            public int? BarberId { get; set; }
            public Barber? Barber { get; set; }


            public string ClientName { get; set; }
            public string ClientPhone { get; set; }


            public List<string> Services { get; set; }


            public decimal Price { get; set; }
            public bool IsReserved { get; set; }

            public int? ClientId { get; set; }
            public Clients? Client { get; set; }
    }
} 



>>>>>>> origin/Mobile
