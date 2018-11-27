namespace Secretary.API.Models
{
    public class CongregacaoEstados : BaseEntity
    {
        public long CongregacaoId { get; set; }
        public long? EstadoId { get; set; }
    }
}