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

    public string AdminCode1 { get; set; }
    public string Lng { get; set; }
    public int GeonameId { get; set; }
    public string ToponymName { get; set; }
    public string Fcl { get; set; }
    public int Population { get; set; }
    public string CountryCode { get; set; }
    public string Name { get; set; }
    public string FclName { get; set; }
    public string AdminCodes1_ISO3166_2 { get; set; }
    public string CountryName { get; set; }
    public string FcodeName { get; set; }
    public string AdminName1 { get; set; }
    public string Lat { get; set; }
    public string Fcode { get; set; }

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
