namespace aspapp.Models
{
    public class trip
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
}
