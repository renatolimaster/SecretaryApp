using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Reuniao : BaseEntity
    {
        public Reuniao()
        {
            AssistenciaReuniao = new HashSet<AssistenciaReuniao>();
            Recibo = new HashSet<Recibo>();
        }

        
        public long AuditoriaUsuario { get; set; }        
        
        public string Descricao { get; set; }
        public string DiaSemana { get; set; }
        public string Hora { get; set; }

        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        // Collections
        public ICollection<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        public ICollection<Recibo> Recibo { get; set; }
    }
}
