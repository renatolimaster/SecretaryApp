using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
  public partial class Country
  {
    public Country()
    {
      Estado = new HashSet<Estado>();
      Publicador = new HashSet<Publicador>();
    }

    public long Id { get; set; }
    
    //

    public string continent { get; set; }
    public string capital { get; set; }

    public string languages { get; set; }
    public int geonameId { get; set; }

    public int south { get; set; }

    public string isoAlpha3 { get; set; }

    public int north { get; set; }

    public int fipsCode { get; set; }

    public int population { get; set; }

    public int east { get; set; }

    public string isoNumeric { get; set; }

    public int areaInSqKm { get; set; }

    public string countryCode { get; set; }

    public int west { get; set; }

    public string countryName { get; set; }

    public string continentName { get; set; }

    public string currencyCode { get; set; }


    //
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
    public ICollection<Publicador> Publicador { get; set; }
  }
}
