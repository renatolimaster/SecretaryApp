using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Familiares
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Observacao { get; set; }
        public string Parentesco { get; set; }
        public long CongregacaoId { get; set; }
        public long MembroId { get; set; }
        public long PublicadorId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Publicador Membro { get; set; }
        public Publicador Publicador { get; set; }
    }
}
