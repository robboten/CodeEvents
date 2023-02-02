﻿namespace CodeEvents.Api.Core.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CityTown { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
