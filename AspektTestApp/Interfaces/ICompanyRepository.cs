using AspektTestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspektTestApp.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task CreateCompany(Company company);
        public Task UpdateCompany(Company company);
        public Task DeleteCompany(int id);
    }
}
