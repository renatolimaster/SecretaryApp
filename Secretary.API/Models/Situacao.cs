using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Situacao : BaseEntity
    {
        public Situacao()
        {
            Publicador = new HashSet<Publicador>();
        }
        
        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        
        [Display(Name = "Description")]
        public string Descricao { get; set; }


        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        // Collections
        [Display(Name = "Publisher")]
        public ICollection<Publicador> Publicador { get; set; }
    }
}
