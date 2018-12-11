using Secretary.API.Model;

namespace Secretary.API.Dtos
{
    public class UserForListDto
    {
        public long id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // ForeignKey
        public CongregationForListDto Congregacao { get; set; }
        public PublisherForListDto Publicador { get; set; }
    }
}