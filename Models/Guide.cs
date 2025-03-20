

namespace aspapp.Models
{
    public class Guide
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty; // np. "Profesjonalny przewodnik"

        // Relacja jeden do wielu (Przewodnik może prowadzić wiele wycieczek)
        public List<Trip> Trips { get; set; } = new();
    }
}
