using System.Linq;
using EasySun.Models;

namespace EasySun.Database
{
    public static class DbInitializer
    {
        public static void Initialize(SunDbContext context)
        {
            // context.Database.EnsureCreated(); // used earlier for testing and prototyping

            // At least one country must be present
            if (context.Countries.Any())
                return; // DB has been seeded

            #region Fill Countries table with test data

            var countries = new Country[]
            {
                new Country { Name = "Ukraine" },
                new Country { Name = "USA" }
            };

            foreach (var country in countries)
                context.Countries.Add(country);

            context.SaveChanges();

            #endregion Fill Countries table with test data

            #region Fill Cities table with test data

            var cities = new City[]
            {
                new City { Name = "Zaporizhzhia", Latitude = 47.8388M, Longitude = 35.1396M, CountryFK = 1 },
                new City { Name = "Washington", Latitude = 47.7511M, Longitude = 120.7401M, CountryFK = 2 }
            };

            foreach (var city in cities)
                context.Cities.Add(city);

            context.SaveChanges();

            #endregion Fill Cities table with test data
        }
    }
}
