using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class AssistenciaReuniao : BaseEntity
    {
        public AssistenciaReuniao()
        {
            Semana1 = 0;
            Semana2 = 0;
            Semana3 = 0;
            Semana4 = 0;
            Semana5 = 0;
        }

        
        [Display(Name = "Reference Year")]
        public int? AnoReferencia { get; set; }
        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        [Display(Name = "Reference")]
        [DisplayFormat(DataFormatString = "{0: MMMM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataReferencia { get; set; } = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.AddMonths(-1).Day + 1);// FIRST DAY OF LAST MOTH      
        [Display(Name = "Average")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public double? Media { get; set; }
        [Display(Name = "Month Reference")]
        public int? MesReferencia { get; set; }
        
        [Display(Name = "Week 1")]
        public int? Semana1 { get; set; } = 0;
        [Display(Name = "Foreigners 1")]
        public int? Estrangeiros1 { get; set; } = 0;
        [Display(Name = "Week 2")]
        public int? Semana2 { get; set; } = 0;
        [Display(Name = "Foreigners 2")]
        public int? Estrangeiros2 { get; set; } = 0;
        [Display(Name = "Week 3")]
        public int? Semana3 { get; set; } = 0;
        [Display(Name = "Foreigners 3")]
        public int? Estrangeiros3 { get; set; } = 0;
        [Display(Name = "Week 4")]
        public int? Semana4 { get; set; } = 0;
        [Display(Name = "Foreigners 4")]
        public int? Estrangeiros4 { get; set; } = 0;
        [Display(Name = "Week 5")]
        public int? Semana5 { get; set; } = 0;
        [Display(Name = "Foreigners 5")]
        public int? Estrangeiros5 { get; set; } = 0;
        [Display(Name = "Total")]
        public int? Total { get; set; }

        // ForeignKey
        public long ReuniaoId { get; set; }
        [Display(Name = "Meetings")]
        public Reuniao Reuniao { get; set; }

        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

    }
}
