using Secretary.API.Models;

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

    }
}