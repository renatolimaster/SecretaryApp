using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Familia : BaseEntity
    {
        
        
        public long AuditoriaUsuario { get; set; }
        
        public string Parentesco { get; set; }

        // Foreignkey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }
        public long ChefeFamiliaId { get; set; }
        [Display(Name = "House Holder")]
        public Publicador ChefeFamilia { get; set; }
        public long MembroId { get; set; }
        [Display(Name = "Family Member")]
        public Publicador Membro { get; set; }
    }
}
