using System;
using Secretary.API.Model;

namespace Secretary.API.Dtos
{
  public class PublisherForListDto
  {
    public long Id { get; set; }
    public string Nome { get; set; }
    public string PrimeiroNome { get; set; }
    public string NomeSobrenome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public DateTime? Batismo { get; set; }
    public int Age { get; set; }
    public long? DianteiraId { get; set; }
    public LeadSimplifiedDto Dianteira { get; set; }
    public long? GrupoId { get; set; }
    public GroupSimplifiedDto Grupo { get; set; }
    public long? PioneiroId { get; set; }
    public string NumeroPioneiro { get; set; }
    public PioneerSimplifiedDto Pioneiro { get; set; }
    public string Sexo { get; set; }
    public string SituacaoServicoCampo { get; set; }
    public string TelCelular { get; set; }
    public SituacaoForListDto Situacao { get; set; }
    public long CongregacaoId { get; set; }
    public StateForListDto Estado { get; set; }
    public CongregationSimplifiedDto Congregacao { get; set; }
  }
}