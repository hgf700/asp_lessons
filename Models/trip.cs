namespace aspapp.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Klucz obcy do przewodnika
        public int GuideId { get; set; }
        public Guide Guide { get; set; } = null!;

        // Relacja wiele do wielu (Wycieczka może mieć wielu podróżników)
        public List<Traveler> Travelers { get; set; } = new();
    }
}
