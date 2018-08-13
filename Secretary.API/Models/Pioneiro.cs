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
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        // ForeignKey
        public long CongregacaoId { get; set; }
        public Congregacao Congregacao { get; set; }

        // Collections
        public ICollection<Publicador> Publicador { get; set; }
        public ICollection<ServicoCampo> ServicoCampo { get; set; }
    }
}
