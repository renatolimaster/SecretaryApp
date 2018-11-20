using Secretary.API.Models;

namespace Secretary.API.Dtos
{
    public class CongregationForListDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Coordenador { get; set; }
        public bool Padrao { get; set; }

        // ADDRESS
        public long? TipoLogradouroId { get; set; }
        public TipoLogradouro TipoLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public long? EstadoId { get; set; }
        public StateForListDto Estado { get; set; }
        public string Cep { get; set; }

        // CONTACT 
        public string Email { get; set; }
        public string TelCelular { get; set; }
        public string TelResidencial { get; set; }
        public string TelTrabalho { get; set; }
        public string Telefone { get; set; }
    }
}