using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class PublicadorHistorico : BaseEntity
    {
        
        public DateTime DataReferencia { get; set; }
        public string Evento { get; set; }
        public string Observacao { get; set; }

        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }
        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }


    }
}
