using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class PublicadorUsuario : BaseEntity
    {

        public long PublicadorId { get; set; }
        public long UsuarioId { get; set; }

        // ForeignKey
        public long CongregacaoId { get; set; }
        public Congregacao Congregacao { get; set; }
    }
}
