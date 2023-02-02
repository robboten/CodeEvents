namespace CodeEvents.Api.Core.Entities
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Website { get; set; }

        public string FullName => FirstName + " " + LastName;

        public ICollection<Lecture>? Lectures { get; set;}
    }
}