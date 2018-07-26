using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class TipoLogradouro : BaseEntity
    {
        public TipoLogradouro()
        {
            Congregacao = new HashSet<Congregacao>();
            Publicador = new HashSet<Publicador>();
        }
        
        public long AuditoriaUsuario { get; set; }
        
        public string Descricao { get; set; }
               
        // Collections
        public ICollection<Congregacao> Congregacao { get; set; }
        public ICollection<Publicador> Publicador { get; set; }
    }
}
