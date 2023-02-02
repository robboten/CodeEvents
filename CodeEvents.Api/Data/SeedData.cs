using Bogus;
using CodeEvents.Api.Core.Entities;
using Microsoft.Extensions.Logging;

namespace CodeEvents.Api.Data
{
    internal class SeedData
    {
        private static CodeEventsApiContext _db;
        public static async Task InitAsync(CodeEventsApiContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            var faker = new Faker<CodeEvent>()
                .StrictMode(false)
                .Rules((f, o) =>
                {
                    o.Name = f.Lorem.Word();
                    o.Description = f.Lorem.Paragraph();
                    o.StartDate = f.Date.Future();
                    o.Duration = new TimeSpan(08, 00, 00);
                    o.Location = new Location()
                    {
                        Address = f.Address.StreetAddress(),
                        CityTown = f.Address.City(),
                        StateProvince = f.Address.State(),
                        PostalCode = f.Address.ZipCode(),
                        Country = f.Address.Country()
                    };
                });

            var codeEvent = faker.Generate(10);

            _db.AddRange(codeEvent);
            await _db.SaveChangesAsync();
        }
    }
}