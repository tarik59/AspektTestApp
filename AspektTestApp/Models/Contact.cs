using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektTestApp.Models
{
    public class Contact
    {
        public int contactId { get; set; }
        public string ContactName { get; set; }
        public Company company { get; set; }
        [ForeignKey("Company")]
        public int companyId { get; set; }
        public Country country { get; set; }
        [ForeignKey("Country")]
        public int countryId { get; set; }

    }
}
