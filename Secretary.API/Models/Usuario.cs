using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Usuario : BaseEntity
    {

        public string Username { get; set; }
        public string Email { get; set; }

        public byte[] PasswordHarsh { get; set; }

        public byte[] PasswordSalt { get; set; }


        // ForeignKey
        public long? CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long? PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }
    }
}
