
namespace aspapp.Models
{
    public class Traveler
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // Relacja wiele do wielu (Podróżnik może brać udział w wielu wycieczkach)
        public List<Trip> Trips { get; set; } = new();
    }
}
