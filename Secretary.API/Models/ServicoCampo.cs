using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class ServicoCampo
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public int? AnoReferencia { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReferencia { get; set; }
        public int? Estudos { get; set; }
        public int? FolhetosBrochuras { get; set; }
        public int? Horas { get; set; }
        public int? Livros { get; set; }
        public int? MesReferencia { get; set; }
        public int? Minutos { get; set; }
        public string Observacao { get; set; }
        public long PioneiroId { get; set; }
        public int? Revisitas { get; set; }
        public int? Revistas { get; set; }
        public int? Publicacoes { get; set; }
        public int? VideosMostrados { get; set; }
        public int HorasBetel { get; set; }
        public int CreditoHoras { get; set; }
        public long CongregacaoId { get; set; }
        public long PublicadorId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Pioneiro Pioneiro { get; set; }
        public Publicador Publicador { get; set; }
    }
}
