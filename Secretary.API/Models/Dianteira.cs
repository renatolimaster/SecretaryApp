using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Dianteira
    {
        public Dianteira()
        {
            Publicador = new HashSet<Publicador>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }
        public long CongregacaoId { get; set; }

        public Congregacao Congregacao { get; set; }
        public ICollection<Publicador> Publicador { get; set; }
    }
}
