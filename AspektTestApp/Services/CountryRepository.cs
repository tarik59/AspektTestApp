using AspektTestApp.Interfaces;
using AspektTestApp.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspektTestApp.Services
{
    public class CountryRepository:ICountryRepository
    {
        private readonly ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateCountry(Country country)
        {
            _db.countries.Add(country);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCountry(Country country)
        {
            _db.countries.Update(country);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCountry(int id)
        {
            var country = await _db.countries.SingleOrDefaultAsync(x => x.countryId == id);
            if (country == null)
                throw new System.Exception();
            _db.countries.Remove(country);
            await _db.SaveChangesAsync();
        }

        public async Task<Country> GetCountry(int id)
        {
            return await _db.countries.SingleOrDefaultAsync(x => x.countryId == id);
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _db.countries.ToListAsync();
        }
    }
}
