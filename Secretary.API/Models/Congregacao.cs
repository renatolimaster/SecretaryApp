using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class Congregacao
    {
        public Congregacao()
        {
            AssistenciaReuniao = new HashSet<AssistenciaReuniao>();
            Dianteira = new HashSet<Dianteira>();
            Familia = new HashSet<Familia>();
            Familiares = new HashSet<Familiares>();
            Grupo = new HashSet<Grupo>();
            PeticaoPioneiroAuxiliar = new HashSet<PeticaoPioneiroAuxiliar>();
            Pioneiro = new HashSet<Pioneiro>();
            PrivilegioCongregacional = new HashSet<PrivilegioCongregacional>();
            Publicador = new HashSet<Publicador>();
            PublicadorHistorico = new HashSet<PublicadorHistorico>();
            PublicadorPrivilegios = new HashSet<PublicadorPrivilegios>();
            PublicadorUsuario = new HashSet<PublicadorUsuario>();
            Recibo = new HashSet<Recibo>();
            Reuniao = new HashSet<Reuniao>();
            ServicoCampo = new HashSet<ServicoCampo>();
            ServicoCampod = new HashSet<ServicoCampod>();
            ServicoCampos = new HashSet<ServicoCampos>();
            ServicoCampot = new HashSet<ServicoCampot>();
            Situacao = new HashSet<Situacao>();
            TransferenciaCongregacao = new HashSet<Transferencia>();
            TransferenciaDestino = new HashSet<Transferencia>();
            TransferenciaOrigem = new HashSet<Transferencia>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Coordenador { get; set; }
        public string Email { get; set; }
        public long? EstadoId { get; set; }
        public Estado Estado { get; set; }
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
        public ICollection<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        public ICollection<Dianteira> Dianteira { get; set; }
        public ICollection<Familia> Familia { get; set; }
        public ICollection<Familiares> Familiares { get; set; }
        public ICollection<Grupo> Grupo { get; set; }
        public ICollection<PeticaoPioneiroAuxiliar> PeticaoPioneiroAuxiliar { get; set; }
        public ICollection<Pioneiro> Pioneiro { get; set; }
        public ICollection<PrivilegioCongregacional> PrivilegioCongregacional { get; set; }
        public ICollection<Publicador> Publicador { get; set; }
        public ICollection<PublicadorHistorico> PublicadorHistorico { get; set; }
        public ICollection<PublicadorPrivilegios> PublicadorPrivilegios { get; set; }
        public ICollection<PublicadorUsuario> PublicadorUsuario { get; set; }
        public ICollection<Recibo> Recibo { get; set; }
        public ICollection<Reuniao> Reuniao { get; set; }
        public ICollection<ServicoCampo> ServicoCampo { get; set; }
        public ICollection<ServicoCampod> ServicoCampod { get; set; }
        public ICollection<ServicoCampos> ServicoCampos { get; set; }
        public ICollection<ServicoCampot> ServicoCampot { get; set; }
        public ICollection<Situacao> Situacao { get; set; }
        public ICollection<Transferencia> TransferenciaCongregacao { get; set; }
        public ICollection<Transferencia> TransferenciaDestino { get; set; }
        public ICollection<Transferencia> TransferenciaOrigem { get; set; }

        public override string ToString()
        {
            return Nome + ":" + Numero;
        }
    }
}
