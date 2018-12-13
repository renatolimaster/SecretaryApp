using System;
using Secretary.API.Model;

namespace Secretary.API.Dtos
{
    public class PublisherForDetailsDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string PrimeiroNome { get; set; }
        public string NomeSobrenome { get; set; }
        //
        public bool? IrmaoBatizado { get; set; }
        public bool? ChefeFamilia { get; set; }
        public DateTime? DataAnciao { get; set; }
        public DateTime? DataInativo { get; set; }
        public DateTime? DataInicioServico { get; set; }
        public DateTime? DataReativado { get; set; }
        public DateTime? DataServoMinisterial { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int Age { get; set; }
        public long? DianteiraId { get; set; }
        public LeadSimplifiedDto Dianteira { get; set; }
        public long? GrupoId { get; set; }
        public GroupSimplifiedDto Grupo { get; set; }
        public long? PioneiroId { get; set; }
        public PioneerSimplifiedDto Pioneiro { get; set; }
        public string Sexo { get; set; }
        public string SituacaoServicoCampo { get; set; }
        public SituacaoForListDto Situacao { get; set; }
        public long CongregacaoId { get; set; }
        public CongregationSimplifiedDto Congregacao { get; set; }
        public DateTime? Batismo { get; set; }
        public string Cep { get; set; }

        // ADDRESS
        public string TelCelular { get; set; }
        public string TelResidencial { get; set; }
        public string TelTrabalho { get; set; }
        public long? TipoLogradouroId { get; set; }
        public TipoLogradouroForListDto TipoLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; } = "fsr.vec@gmail.com";
        public long? EstadoId { get; set; }
        public EstadoForListDto Estado { get; set; }
        public int CountryId { get; set; }
        public CountryForListDto Country { get; set; }

    }
}