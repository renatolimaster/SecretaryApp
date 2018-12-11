using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class PublicadorUsuario
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long PublicadorId { get; set; }
        public long UsuarioId { get; set; }
        public long CongregacaoId { get; set; }

        public Congregacao Congregacao { get; set; }
    }
}
