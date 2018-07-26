using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Recibo : BaseEntity
    {
        
        public int AnoMesReferencia { get; set; }
        public long AuditoriaUsuario { get; set; }
        public DateTime Data { get; set; }
       
        public string Destino { get; set; }
        
        public string OutroDestino { get; set; }
        
        public double Valor { get; set; }


        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long ReuniaoId { get; set; }
        [Display(Name = "Reuniao")]
        public Reuniao Reuniao { get; set; }

    }
}
