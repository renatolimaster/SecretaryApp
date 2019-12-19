using System;

namespace Secretary.API.Dtos
{
  public class SituationForListDto
  {
    public long Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string Ipaddress { get; set; }
    public long AuditoriaUsuario { get; set; }
    public string Descricao { get; set; }
    public long CongregacaoId { get; set; }
  }
}