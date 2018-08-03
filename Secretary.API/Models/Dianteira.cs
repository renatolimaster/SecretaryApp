using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Dianteira : BaseEntity
    {
        public Dianteira()
        {
            Publicador = new HashSet<Publicador>();
        }

        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        
        [Display(Name = "Description")]
        public string Descricao { get; set; }

        // Foreignkey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        // Collection    
        public ICollection<Publicador> Publicador { get; set; }
    }
}
