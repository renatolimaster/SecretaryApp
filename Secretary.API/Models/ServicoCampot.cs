using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class ServicoCampot : BaseEntity
    {
        
        public double Estudos { get; set; }
        public double FolhetosBrochuras { get; set; }
        public double Horas { get; set; }
        public double HorasBetel { get; set; }
        public double CreditoHoras { get; set; }
        public double Livros { get; set; }
        public double Minutos { get; set; }
        public double Revisitas { get; set; }
        public double Revistas { get; set; }
        public double Publicacoes { get; set; }
        public double VideosMostrados { get; set; }

        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }
    }
}
