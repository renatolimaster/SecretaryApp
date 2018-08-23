namespace Secretary.API.Dtos
{
    public class PioneerForDetailDto
    {
        public long Id { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }        
        public CongregationSimplifiedDto Congregacao { get; set; }
    }
}