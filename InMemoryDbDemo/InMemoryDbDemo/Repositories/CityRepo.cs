using InMemoryDbDemo.Data;
using InMemoryDbDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace InMemoryDbDemo.Repositories
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _db;
        public CityRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _db.Cities.Include(x => x.PointOfInterests).ToListAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync()
        {
            return await _db.PointOfInterests.ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _db.Cities.Where(x => x.Id == id).Include(x=>x.PointOfInterests).FirstOrDefaultAsync();
        }

        public async Task<City> AddCityAsync(City city)
        {
            await _db.Cities.AddAsync(city);
            await _db.SaveChangesAsync();
            return city;
        }
    }
}
