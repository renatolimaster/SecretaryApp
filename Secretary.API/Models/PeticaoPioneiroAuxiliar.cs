using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class PeticaoPioneiroAuxiliar
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public DateTime ReferenciaInicial { get; set; }
        public DateTime ReferenciaFinal { get; set; }
        public long CongregacaoId { get; set; }
        public long PublicadorId { get; set; }
        public long PioneiroId { get; set; }
        public bool EstaAprovado { get; set; }
        public string Observacao { get; set; }

        public Congregacao Congregacao { get; set; }
        public Pioneiro Pioneiro { get; set; }
        public Publicador Publicador { get; set; }
    }
}
