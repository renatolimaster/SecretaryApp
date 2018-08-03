using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Familiares : BaseEntity
    {


        public long AuditoriaUsuario { get; set; }

        public string Observacao { get; set; }
        public string Parentesco { get; set; }

        // Foreignkey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }
        public long MembroId { get; set; }
        [Display(Name = "Family Member")]
        public Publicador Membro { get; set; }
        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }
    }
}
