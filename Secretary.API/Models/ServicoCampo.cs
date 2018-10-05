using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Secretary.API.Models
{
    public partial class ServicoCampo : BaseEntity
    {
        public ServicoCampo()
        {
            FolhetosBrochuras = 0;
            Revisitas = 0;
            Minutos = 0;
            Revistas = 0;
            Livros = 0;
        }
        public int? AnoReferencia { get; set; }
        public int? MesReferencia { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReferencia { get; set; }
        public int? Estudos { get; set; }
        public int? FolhetosBrochuras { get; set; }
        public int? Horas { get; set; }
        public int? Livros { get; set; }
        public int? Minutos { get; set; }
        public string Observacao { get; set; }
        public int? Revisitas { get; set; }
        public int? Revistas { get; set; }
        public int? Publicacoes { get; set; }
        public int? VideosMostrados { get; set; }
        public int HorasBetel { get; set; }
        public int CreditoHoras { get; set; }
        // ForeignKey
        public long PioneiroId { get; set; }
        public Pioneiro Pioneiro { get; set; }
        public long CongregacaoId { get; set; }
        public Congregacao Congregacao { get; set; }
        public long PublicadorId { get; set; }
        public Publicador Publicador { get; set; }
    }
}
