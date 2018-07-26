using System;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public class PeticaoPioneiroAuxiliar : BaseEntity
    {

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM/yyyy}")]
        public DateTime ReferenciaInicial { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM/yyyy}")]
        public DateTime ReferenciaFinal { get; set; }

        [Display(Name = "Notes")]
        public string Observacao { set; get; }

        [Display(Name = "Status")]
        public bool? EstaAprovado { set; get; }

        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }
        
        public long PioneiroId { get; set; }
        [Display(Name = "Pioneer")]
        public Pioneiro Pioneiro { get; set; }
    }
}