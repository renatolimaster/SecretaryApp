using System;
using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class FieldServiceForUpdateDto
    {
        // public long Id { get; set; }
        public int? AnoReferencia { get; set; }
        public int? MesReferencia { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReferencia { get; set; }
        public int? Estudos { get; set; }
        public int? Horas { get; set; }        
        public int? Minutos { get; set; }
        public int? Revisitas { get; set; }
        public int? Publicacoes { get; set; }
        public int? VideosMostrados { get; set; }
        public int HorasBetel { get; set; }
        public int CreditoHoras { get; set; }
        // ForeignKey
        public long PioneiroId { get; set; }
        // public Pioneiro Pioneiro { get; set; }
        public long CongregacaoId { get; set; }
        // public Congregacao Congregacao { get; set; }
        public long PublicadorId { get; set; }
        // public Publicador Publicador { get; set; }
    }
}