using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Secretary.API.Models
{
    public partial class ServicoCampo : BaseEntity
    {




        [Display(Name = "Reference Year")]
        public int? AnoReferencia { get; set; }

        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM/yyyy}")]
        public DateTime DataEntrega { get; set; }

        [Display(Name = "Reference Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM/yyyy}")]
        public DateTime DataReferencia { get; set; }

        [Display(Name = "Studies")]
        public int? Estudos { get; set; }

        [Display(Name = "Brochures")]
        public int? FolhetosBrochuras { get; set; }

        [Display(Name = "Hours")]
        public int? Horas { get; set; }

        [Display(Name = "Books")]
        public int? Livros { get; set; }

        [Display(Name = "Reference Month")]
        public int? MesReferencia { get; set; }

        [Display(Name = "Minutes")]
        public int? Minutos { get; set; }

        [Display(Name = "Observations")]
        public string Observacao { get; set; }

        [Display(Name = "Pioneer")]
        public long PioneiroId { get; set; }

        [Display(Name = "Return Visits")]
        public int? Revisitas { get; set; }

        [Display(Name = "Magazines")]
        public int? Revistas { get; set; }

        [Display(Name = "Placements")]
        public int? Publicacoes { get; set; }

        [Display(Name = "Videos")]
        public int? VideosMostrados { get; set; }

        [Display(Name = "Betel Hours")]
        public int HorasBetel { get; set; }
        
        [Display(Name = "Credits Hours")]
        public int CreditoHoras { get; set; }

        [Display(Name = "Pioneer")]
        public Pioneiro Pioneiro { get; set; }


        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }
    }
}
