using InMemoryDbDemo.Entities;

namespace InMemoryDbDemo.Repositories
{
    public interface ICityRepo
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync();
        Task<City> GetCityByIdAsync(int id);
        Task<City> AddCityAsync(City city);
    }
}