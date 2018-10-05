using System;
using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class FieldServiceForListDto
    {
        public long Id { get; set; }
        public int? AnoReferencia { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReferencia { get; set; }
        public int? Estudos { get; set; }
        public int? Horas { get; set; }
        public int? MesReferencia { get; set; }
        public int? Minutos { get; set; }
        public int? Revisitas { get; set; }
        public int? Publicacoes { get; set; }
        public string Observacao { get; set; }
        public int? VideosMostrados { get; set; }
        public int HorasBetel { get; set; }
        public int CreditoHoras { get; set; }
        public PioneerSimplifiedDto Pioneiro { get; set; }
        // ForeignKey
        public CongregationSimplifiedDto Congregacao { get; set; }
        public PublisherSimplifiedDto Publicador { get; set; }
    }
}