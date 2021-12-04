using AspektTestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspektTestApp.Interfaces
{
    public interface ICountryRepository
    {
        public Task<IEnumerable<Country>> GetCountries();
        public Task<Country> GetCountry(int id);
        public Task CreateCountry(Country country);
        public Task UpdateCountry(Country country);
        public Task DeleteCountry(int id);
    }
}
