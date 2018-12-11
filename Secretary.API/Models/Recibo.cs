using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Recibo
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public int AnoMesReferencia { get; set; }
        public long AuditoriaUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Destino { get; set; }
        public string OutroDestino { get; set; }
        public double Valor { get; set; }
        public long CongregacaoId { get; set; }
        public long ReuniaoId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Reuniao Reuniao { get; set; }
    }
}
