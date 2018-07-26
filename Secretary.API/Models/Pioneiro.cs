using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Pioneiro : BaseEntity
    {
        public Pioneiro()
        {
            Publicador = new HashSet<Publicador>();
            ServicoCampo = new HashSet<ServicoCampo>();
        }

        
        
        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        
        [Display(Name = "Description")]
        public string Descricao { get; set; }
        
        [Display(Name = "Obs")]
        public string Observacao { get; set; }

        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        // Collections
        public ICollection<Publicador> Publicador { get; set; }
        public ICollection<ServicoCampo> ServicoCampo { get; set; }
    }
}
