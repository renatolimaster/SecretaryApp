using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Grupo
    {
        public Grupo()
        {
            Publicador = new HashSet<Publicador>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Local { get; set; }
        public long? AjudanteId { get; set; }
        public long CongregacaoId { get; set; }
        public long? SuperintendenteId { get; set; }

        public Publicador Ajudante { get; set; }
        public Congregacao Congregacao { get; set; }
        public Publicador Superintendente { get; set; }
        public ICollection<Publicador> Publicador { get; set; }
    }
}
