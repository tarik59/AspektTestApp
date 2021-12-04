using AspektTestApp.Interfaces;
using AspektTestApp.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspektTestApp.Services
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateCompany(Company company)
        {
            _db.companies.Add(company);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCompany(Company company)
        {
            _db.companies.Update(company);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCompany(int id)
        {
            var company = await _db.companies.SingleOrDefaultAsync(x => x.companyId == id);
            if (company == null)
                throw new System.Exception();
            _db.companies.Remove(company);
            await _db.SaveChangesAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await _db.companies.SingleOrDefaultAsync(x => x.companyId == id);
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _db.companies.ToListAsync();
        }
    }
}
