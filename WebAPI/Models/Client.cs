namespace WebAPI.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
<<<<<<< HEAD:WebAPI/Models/Client.cs
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
=======
        public string Password { get; set; }
        public string Role { get; set; }
>>>>>>> origin/Mobile:WebAPI/Models/Clients.cs
    }
}
