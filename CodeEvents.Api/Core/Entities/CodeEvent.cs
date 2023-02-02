namespace CodeEvents.Api.Core.Entities
{
    public class CodeEvent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Speaker? Speaker { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate => StartDate + Duration;
        public TimeSpan? Duration { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public ICollection<Lecture>? Lectures { get; set; }
    }
}
