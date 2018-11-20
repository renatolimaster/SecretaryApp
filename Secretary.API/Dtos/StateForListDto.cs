using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class StateForListDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long? CountryId { get; set; }
        public CountryForListDto Country { get; set; }        
    }
}