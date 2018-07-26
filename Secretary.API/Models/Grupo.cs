using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Grupo : BaseEntity
    {
        public Grupo()
        {
            Publicador = new HashSet<Publicador>();
        }

        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }

        [Display(Name = "Local")]
        public string Local { get; set; }

        // ForeingKey
        public long? AjudanteId { get; set; }
        [Display(Name = "Helper")]
        public Publicador Ajudante { get; set; }

        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long? SuperintendenteId { get; set; }
        [Display(Name = "Elder")]
        public Publicador Superintendente { get; set; }

        // Collections
        [Display(Name = "Publisher")]
        public ICollection<Publicador> Publicador { get; set; }
    }
}
