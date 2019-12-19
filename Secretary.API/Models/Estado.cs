using System;
using System.Collections.Generic;
using Secretary.API.Models;

namespace Secretary.API.Model
{
  public partial class Estado
  {
    public Estado()
    {
      Cidade = new HashSet<Cidade>();
      Publicador = new HashSet<Publicador>();
    }

    public long Id { get; set; }
    //

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
    public string lat { get; set; }
    public string fcode { get; set; }

    //
    public DateTime DateCreated { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string Ipaddress { get; set; }
    public long AuditoriaUsuario { get; set; }
    public string Descricao { get; set; }
    public long? CountryId { get; set; }

    public Country Country { get; set; }
    public ICollection<Publicador> Publicador { get; set; }
    public ICollection<Cidade> Cidade { get; set; }
  }
}
