using System.Collections.Generic;
using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class LeadForListDto
    {        
        public long Id { get; set; }
        public string Descricao { get; set; }        
        public CongregationForListDto Congregacao { get; set; }
        // Collection    
        public ICollection<PublisherSimplifiedDto> Publicador { get; set; }
    }
}