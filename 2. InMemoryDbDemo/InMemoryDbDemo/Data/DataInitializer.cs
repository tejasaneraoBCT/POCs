﻿using InMemoryDbDemo.Entities;

namespace InMemoryDbDemo.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext context)
        {
            context.Cities.Add(new City
            {
                Name = "Pune",
                Description = "Pune is the second-largest city in the state of Maharashtra after Mumbai, and is an important city in terms of its economic and industrial growth.",
                PointOfInterests = new List<PointOfInterest>
                {
                    new PointOfInterest
                    {
                        Name = "Shaniwar Wada",
                        Description = "Shaniwar Wada a 13 storey palace of Peshwas was built by Bajirao-I, in the year 1736.It was head quarter of the Peshwas and it symbolizes Pune's culture. The structure was built giving security the highest priority. The main entrance is known as 'Delhi Darwaja' & others have names like Ganesh, Mastani, Jambhal, Khidki."
                    }
                }
            });
            context.Cities.Add(new City
            {
                Name = "Mumbai",
                Description = "Mumbai, formerly Bombay, city, capital of Maharashtra state, southwestern India. It is the country’s financial and commercial centre and its principal port on the Arabian Sea.",
                PointOfInterests = new List<PointOfInterest>
                {
                    new PointOfInterest
                    {
                        Name = "Gateway of India",
                        Description = "Lorema sadasdi oasido noiasdoi oiasdhiuhne oaishd"
                    }
                }
            });
            context.Cities.Add(new City
            {
                Name = "Bangalore",
                Description = "Bengaluru (also called Bangalore) is the capital of India's southern Karnataka state. The center of India's high-tech industry, the city is also known for its parks and nightlife.",
                PointOfInterests = new List<PointOfInterest>
                {
                    new PointOfInterest
                    {
                        Name = "Tipu Sultan’s Summer Palace",
                        Description = "Lorema sadasdi oasido noiasdoi oiasdhiuhne oaishd"
                    }
                }
            });

            context.SaveChanges();
        }
    }
}
