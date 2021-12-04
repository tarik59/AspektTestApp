using AspektTestApp.Interfaces;
using AspektTestApp.Models;
using AspektTestApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspektTestApp.Controllers
{
    public class ContactsController : BaseApiController
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            return Ok(await _contactRepository.GetContacts());
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            return Ok(await _contactRepository.GetContact(id));
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task Post([FromBody] Contact value)
        {
           await _contactRepository.CreateContact(value);
        }

        // PUT api/<ContactsController>/5
        [HttpPut]
        public async Task Put([FromBody] Contact value)
        {
          await  _contactRepository.UpdateContact(value);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          await  _contactRepository.DeleteContact(id);
        }
        [HttpGet("GetContactsWithCompanyAndCountry")]
        public async Task<ActionResult<Contact>> GetContactsWithCompanyAndCountry()
        {
            return Ok(await _contactRepository.GetContactsWithCompanyAndCountry());
        }
        [HttpGet("filter/{companyId?}/{countryId?}")]
        public async Task<ActionResult<IEnumerable<FilterDto>>> FilterContact(int companyId, int countryId)
        {
            return Ok(await _contactRepository.FilterContact(companyId,countryId));
        }
    }
}
