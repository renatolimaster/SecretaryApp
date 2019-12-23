using Secretary.API.Model;

namespace Secretary.API.Models
{
  public class Cidade
  {

    public long Id { get; set; }

    public string AdminCode1 { get; set; }
    public string Lng { get; set; }
    public int GeonameId { get; set; }
    public string ToponymName { get; set; }
    public long? CountryId { get; set; }
    public string Fcl { get; set; }
    public int Population { get; set; }
    public string CountryCode { get; set; }
    public string Name { get; set; }
    public string FclName { get; set; }
    public string AdminCodes1_ISO3166_2 { get; set; }
    public string CountryName { get; set; }
    public string FcodeName { get; set; }
    public string AdminName1 { get; set; }
    public string Fcode { get; set; }

    public long? EstadoId { get; set; }

    public Estado Estado { get; set; }
  }
}