namespace Secretary.API.Dtos
{
  public class CountryForListDto
  {
    public long Id { get; set; }
    public string Iso { get; set; }
    public string Name { get; set; }
    public string NiceName { get; set; }
    public string Iso3 { get; set; }
    public int? NumCode { get; set; }
    public int PhoneCode { get; set; }

    //

    public string Continent { get; set; }
    public string Capital { get; set; }

    public string Languages { get; set; }
    public int GeonameId { get; set; }

    public int South { get; set; }

    public string IsoAlpha3 { get; set; }

    public int North { get; set; }

    public int FipsCode { get; set; }

    public int Population { get; set; }

    public int East { get; set; }

    public string IsoNumeric { get; set; }

    public int AreaInSqKm { get; set; }

    public string CountryCode { get; set; }

    public int West { get; set; }

    public string CountryName { get; set; }

    public string ContinentName { get; set; }

    public string CurrencyCode { get; set; }
  }
}