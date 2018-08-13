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
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }

        // Foreignkey
        public long CongregacaoId { get; set; }
        public Congregacao Congregacao { get; set; }
        // Collection    
        public ICollection<Publicador> Publicador { get; set; }
    }
}
