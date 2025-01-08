namespace WebAPI.Models
{
    public class Review
    {
        public int Id { get; set; } 

        public int? BarberId { get; set; } 
        public Barber? Barber { get; set; } 

        public int Rating { get; set; }

        public string? Comment { get; set; } 

        public DateTime CreatedAt { get; set; } 
    }
}

