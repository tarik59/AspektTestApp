using AspektTestApp.Interfaces;
using AspektTestApp.Models;
using AspektTestApp.Models.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspektTestApp.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateContact(Contact contact)
        {
            _db.contacts.Add(contact);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _db.contacts.SingleOrDefaultAsync(x => x.contactId == id);
            if (contact == null)
                throw new System.Exception();
            _db.contacts.Remove(contact);
            await _db.SaveChangesAsync();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _db.contacts.SingleOrDefaultAsync(x => x.contactId == id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _db.contacts.ToListAsync();
        }
        public async Task<IEnumerable<Contact>> GetContactsWithCompanyAndCountry()
        {
            return await _db.contacts
                .Include(x => x.country)
                .Include(x => x.company)
                .ToListAsync();
        }
        public async Task<IEnumerable<FilterDto>> FilterContact(int companyId,int countryId)
        {
            return await _db.contacts
                .Include(x => x.country)
                .Include(x => x.company)
                .Where(x => !countryId.Equals(0) ? x.countryId == countryId : true)
                .Where(x=>!companyId.Equals(0)?x.companyId==companyId:true)
                .GroupBy(x => new {x.ContactName,x.countryId,x.companyId })
                .Select(x =>new FilterDto
                {
                    ContactName=x.Key.ContactName,
                    countryId=x.Key.countryId,
                    companyId=x.Key.companyId
                })
                .ToListAsync();
        }

        public async Task UpdateContact(Contact contact)
        {
            _db.contacts.Update(contact);
            await _db.SaveChangesAsync();
        }
    }
}
