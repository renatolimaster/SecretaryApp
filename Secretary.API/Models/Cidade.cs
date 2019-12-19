using Secretary.API.Model;

namespace Secretary.API.Models
{
  public class Cidade
  {

    public long Id { get; set; }

    public string adminCode1 { get; set; }
    public string lng { get; set; }
    public int geonameId { get; set; }
    public string toponymName { get; set; }
    public string countryId { get; set; }
    public string fcl { get; set; }
    public int population { get; set; }
    public string countryCode { get; set; }
    public string name { get; set; }
    public string fclName { get; set; }
    public string adminCodes1_ISO3166_2 { get; set; }
    public string countryName { get; set; }
    public string fcodeName { get; set; }
    public string adminName1 { get; set; }
    public string fcode { get; set; }

    public long? EstadoId { get; set; }

    public Estado Estado { get; set; }
  }
}