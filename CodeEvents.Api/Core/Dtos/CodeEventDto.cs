using CodeEvents.Api.Core.Entities;

namespace CodeEvents.Api.Core.Dtos
{
    public class CodeEventDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Speaker? Speaker { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate => StartDate + Duration;
        public TimeSpan? Duration { get; set; }
        public string LocationCountry { get; set; }
        public string LocationCityTown { get; set; }
        //public ICollection<Lecture>? Lectures { get; set; }
    }
}
