namespace Secretary.API.Dtos
{
    public class CongregationForCreateDto
    {
        public long Id { get; set;}
        public long AuditoriaUsuario { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Coordenador { get; set; }
        public string Email { get; set; }
        public long EstadoId { get; set; }
        public string Nome { get; set; }
        public string NomeLogradouro { get; set; }
        public string Numero { get; set; }
        public bool Padrao { get; set; }
        public string TelCelular { get; set; }
        public string TelResidencial { get; set; }
        public string TelTrabalho { get; set; }
        public string Telefone { get; set; }
        public long? TipoLogradouroId { get; set; }
    }
}