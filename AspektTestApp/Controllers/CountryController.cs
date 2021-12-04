using AspektTestApp.Interfaces;
using AspektTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspektTestApp.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        // GET: api/<CountrysController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return Ok(await _countryRepository.GetCountries());
        }

        // GET api/<CountrysController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            return Ok(await _countryRepository.GetCountry(id));
        }

        // POST api/<CountrysController>
        [HttpPost]
        public async Task Post([FromBody] Country value)
        {
            await _countryRepository.CreateCountry(value);
        }

        // PUT api/<CountrysController>/5
        [HttpPut]
        public async Task Put([FromBody] Country value)
        {
            await _countryRepository.UpdateCountry(value);
        }

        // DELETE api/<CountrysController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _countryRepository.DeleteCountry(id);
        }
    }
}
