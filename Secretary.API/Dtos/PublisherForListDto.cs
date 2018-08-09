using System;
using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class PublisherForListDto
    {
        public string Nome { get; set; }
        public string NomeSobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int Age { get; set; }
        public long? DianteiraId { get; set; }
        public Dianteira Dianteira { get; set; }
        public long? GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public long? PioneiroId { get; set; }    
        public Pioneiro Pioneiro { get; set; }         
        public string Sexo { get; set; }
        public string SituacaoServicoCampo { get; set; }
        public string TelCelular { get; set; }                   
        public Situacao Situacao { get; set; }
        public long CongregacaoId { get; set; }        
        public CongregationForListDto Congregacao { get; set; }
    }
}