using Secretary.API.Model;
using System;

namespace Secretary.API.Dtos
{
  public class PublisherSimplifiedDto
  {
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Anointed { get; set; }
    public string Sexo { get; set; }
    public DateTime? Batismo { get; set; }
    public string NumeroPioneiro { get; set; }
    public LeadSimplifiedDto Dianteira { get; set; }
    public string PrimeiroNome { get; set; }
    public string NomeSobrenome { get; set; }
    public string TelCelular { get; set; }
    public string SituacaoServicoCampo { get; set; }
    public GroupSimplifiedDto Grupo { get; set; }

  }
}