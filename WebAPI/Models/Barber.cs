using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }

        public double? AverageRating { get; set; }

        [JsonIgnore]
        public ICollection<Service> Services { get; set; } = new List<Service>();

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();
    }
}
