using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class PublicadorPrivilegios : BaseEntity
    {
        [Display(Name = "Privilege")]
        public long PrivilegioCongregacionalId { get; set; }

        [Display(Name = "Privilege")]
        public PrivilegioCongregacional PrivilegioCongregacional { get; set; }
        

        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }
    }
}
