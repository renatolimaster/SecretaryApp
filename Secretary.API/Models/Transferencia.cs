using System;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Transferencia : BaseEntity
    {
        
        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        
        [Display(Name = "Obs")]
        public string Observacao { get; set; }
        
        
        // ForeignKey
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }

        public long PublicadorId { get; set; }
        [Display(Name = "Publisher")]
        public Publicador Publicador { get; set; }

        public long OrigemId { get; set; }
        [Display(Name = "Origin")]
        public Congregacao Origem { get; set; }

        public long DestinoId { get; set; }
        [Display(Name = "Destination")]
        public Congregacao Destino { get; set; }


    }

}
