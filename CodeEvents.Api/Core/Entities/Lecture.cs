namespace CodeEvents.Api.Core.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Level { get; set; }

        public Speaker? Speaker { get; set; }

        public CodeEvent? CodeEvent { get; set; }

    }
}
