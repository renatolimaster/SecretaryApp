using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class ServicoCampot
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
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
        public long CongregacaoId { get; set; }
        public long PublicadorId { get; set; }

        public Congregacao Congregacao { get; set; }
        public Publicador Publicador { get; set; }
    }
}
