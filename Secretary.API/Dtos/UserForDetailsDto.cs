using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class UserForDetailsDto
    {
        public long id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        
        // ForeignKey
        public long CongregacaoId { get; set; }        
        public CongregationForListDto Congregacao { get; set; }

        public long PublicadorId { get; set; }

        public PublisherForListDto Publicador { get; set; }
    }
}