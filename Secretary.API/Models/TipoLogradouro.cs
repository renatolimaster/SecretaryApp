using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class TipoLogradouro
    {
        public TipoLogradouro()
        {
            Congregacao = new HashSet<Congregacao>();
            Publicador = new HashSet<Publicador>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }

        public ICollection<Congregacao> Congregacao { get; set; }
        public ICollection<Publicador> Publicador { get; set; }
    }
}
