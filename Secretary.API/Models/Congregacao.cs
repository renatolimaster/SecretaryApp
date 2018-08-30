using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Congregacao : BaseEntity
    {
        public Congregacao()
        {
            Familia = new HashSet<Familia>();
            Grupo = new HashSet<Grupo>();
            Publicador = new HashSet<Publicador>();
            Reuniao = new HashSet<Reuniao>();
            ServicoCampo = new HashSet<ServicoCampo>();
            TransferenciaDestino = new HashSet<Transferencia>();
            TransferenciaOrigem = new HashSet<Transferencia>();
        }
        public long AuditoriaUsuario { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Coordenador { get; set; }
        public string Email { get; set; }
        public long? EstadoId { get; set; }
        public int CountryId { get; set; }
        public string Nome { get; set; }
        public string NomeLogradouro { get; set; }
        public string Numero { get; set; }
        public bool Padrao { get; set; }
        public string TelCelular { get; set; }
        public string TelResidencial { get; set; }
        public string TelTrabalho { get; set; }
        public string Telefone { get; set; }
        public long? TipoLogradouroId { get; set; }
        public TipoLogradouro TipoLogradouro { get; set; }
        public Estado Estado { get; set; }
        // Collections
        public ICollection<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        public ICollection<Dianteira> Dianteira { get; set; }
        public ICollection<Familia> Familia { get; set; }
        public ICollection<Familiares> Familiares { get; set; }
        public ICollection<Grupo> Grupo { get; set; }
        public ICollection<Publicador> Publicador { get; set; }
        public ICollection<Reuniao> Reuniao { get; set; }
        public ICollection<ServicoCampo> ServicoCampo { get; set; }
        public ICollection<ServicoCampod> ServicoCampod { get; set; }
        public ICollection<ServicoCampos> ServicoCampos { get; set; }
        public ICollection<ServicoCampot> ServicoCampot { get; set; }
        public ICollection<Transferencia> TransferenciaDestino { get; set; }
        public ICollection<Transferencia> TransferenciaOrigem { get; set; }
        public ICollection<Pioneiro> Pioneiro { get; set; }
        public ICollection<PrivilegioCongregacional> PrivilegioCongregacional { get; set; }
        public ICollection<Situacao> Situacao { get; set; }
        public override string ToString()
        {
            return Nome + ":" + Numero;
        }
    }
}
