namespace WebAPI.Models
{
    public class Service
    {
<<<<<<< HEAD
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
=======
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; } 
        public int? BarberId { get; set; }
        public Barber? Barber { get; set; }
>>>>>>> origin/Mobile
    }
}
