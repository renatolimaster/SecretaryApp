using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Reuniao
    {
        public Reuniao()
        {
            AssistenciaReuniao = new HashSet<AssistenciaReuniao>();
            Recibo = new HashSet<Recibo>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }
        public string DiaSemana { get; set; }
        public string Hora { get; set; }
        public long CongregacaoId { get; set; }

        public Congregacao Congregacao { get; set; }
        public ICollection<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        public ICollection<Recibo> Recibo { get; set; }
    }
}
