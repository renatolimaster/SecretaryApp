using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class PublicadorHistorico
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public DateTime DataReferencia { get; set; }
        public string Evento { get; set; }
        public string Observacao { get; set; }
        public long CongregacaoId { get; set; }
        public long PublicadorId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Publicador Publicador { get; set; }
    }
}
