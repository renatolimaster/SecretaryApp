using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class AssistenciaReuniao
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public int? AnoReferencia { get; set; }
        public long AuditoriaUsuario { get; set; }
        public DateTime DataReferencia { get; set; }
        public double? Media { get; set; }
        public int? MesReferencia { get; set; }
        public int? Semana1 { get; set; }
        public int? Estrangeiros1 { get; set; }
        public int? Semana2 { get; set; }
        public int? Estrangeiros2 { get; set; }
        public int? Semana3 { get; set; }
        public int? Estrangeiros3 { get; set; }
        public int? Semana4 { get; set; }
        public int? Estrangeiros4 { get; set; }
        public int? Semana5 { get; set; }
        public int? Estrangeiros5 { get; set; }
        public int? Total { get; set; }
        public long ReuniaoId { get; set; }
        public long CongregacaoId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Reuniao Reuniao { get; set; }
    }
}
