using AspektTestApp.Interfaces;
using AspektTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspektTestApp.Controllers
{
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }

        // GET: api/<companysController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return Ok(await _companyRepository.GetCompanies());
        }

        // GET api/<companysController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            return Ok(await _companyRepository.GetCompany(id));
        }

        // POST api/<companysController>
        [HttpPost]
        public async Task Post([FromBody] Company value)
        {
            await _companyRepository.CreateCompany(value);
        }

        // PUT api/<companysController>/5
        [HttpPut]
        public async Task Put([FromBody] Company value)
        {
            await _companyRepository.UpdateCompany(value);
        }

        // DELETE api/<companysController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _companyRepository.DeleteCompany(id);
        }
    }
}
