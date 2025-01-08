<<<<<<< HEAD
﻿namespace WebAPI.Models
{
    public class Barber
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
=======
﻿using System.Text.Json.Serialization;

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
>>>>>>> origin/Mobile
    }
}
