using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Transferencia
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public long CongregacaoId { get; set; }
        public long PublicadorId { get; set; }
        public long OrigemId { get; set; }
        public long DestinoId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Congregacao Destino { get; set; }
        public Congregacao Origem { get; set; }
        public Publicador Publicador { get; set; }
    }
}
