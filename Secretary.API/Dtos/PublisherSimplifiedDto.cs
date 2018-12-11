using Secretary.API.Model;

namespace Secretary.API.Dtos
{
    public class PublisherSimplifiedDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public LeadSimplifiedDto Dianteira { get; set; }
        public string PrimeiroNome { get; set; }
        public string NomeSobrenome { get; set; }
        public string TelCelular { get; set; } 
        public string SituacaoServicoCampo { get; set; }
        public GroupSimplifiedDto Grupo { get; set; }

    }
}