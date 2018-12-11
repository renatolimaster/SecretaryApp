using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Usuario
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long? CongregacaoId { get; set; }
        public Congregacao Congregacao { get; set; }
        public long? PublicadorId { get; set; }
        public Publicador Publicador { get; set; }
        public byte[] PasswordHarsh { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
