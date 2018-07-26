using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class PrivilegioCongregacional : BaseEntity
    {
        public PrivilegioCongregacional()
        {
            PublicadorPrivilegios = new HashSet<PublicadorPrivilegios>();
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
        public ICollection<PublicadorPrivilegios> PublicadorPrivilegios { get; set; }
    }
}
