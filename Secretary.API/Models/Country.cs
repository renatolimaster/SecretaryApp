using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Country
    {
        public Country()
        {
            Estado = new HashSet<Estado>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string Iso3 { get; set; }
        public int? NumCode { get; set; }
        public int PhoneCode { get; set; }

        public ICollection<Estado> Estado { get; set; }
    }
}
