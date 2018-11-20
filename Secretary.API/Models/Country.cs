using System.Collections.Generic;

namespace Secretary.API.Models
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Estado = new HashSet<Estado>();
        }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string Iso3 { get; set; }
        public int? NumCode { get; set; }
        public int PhoneCode { get; set; }
        public ICollection<Estado> Estado { get; set; }
    }
}