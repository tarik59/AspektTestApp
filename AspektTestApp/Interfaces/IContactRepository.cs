using AspektTestApp.Models;
using AspektTestApp.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspektTestApp.Interfaces
{
    public interface IContactRepository
    {
        public Task<IEnumerable<Contact>> GetContacts();
        public Task<Contact> GetContact(int id);
        public Task CreateContact(Contact contact);
        public Task UpdateContact(Contact contact);
        public Task DeleteContact(int id);
        public Task<IEnumerable<Contact>> GetContactsWithCompanyAndCountry();
        public Task<IEnumerable<FilterDto>> FilterContact(int companyId, int countryId);

    }
}
