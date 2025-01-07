using Mobile.Models;

namespace WebAPI.Models
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


        public string ServicesString
        {
            get
            {
                return string.Join(", ", Services); 
            }
        }

        public decimal Price { get; set; }
            public bool IsReserved { get; set; }

            public int? ClientId { get; set; }
            public Clients? Client { get; set; }

    }
} 



