using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
  public partial class Publicador
  {
    public Publicador()
    {
      FamiliaChefeFamilia = new HashSet<Familia>();
      FamiliaMembro = new HashSet<Familia>();
      FamiliaresMembro = new HashSet<Familiares>();
      FamiliaresPublicador = new HashSet<Familiares>();
      GrupoAjudante = new HashSet<Grupo>();
      GrupoSuperintendente = new HashSet<Grupo>();
      PeticaoPioneiroAuxiliar = new HashSet<PeticaoPioneiroAuxiliar>();
      PublicadorHistorico = new HashSet<PublicadorHistorico>();
      PublicadorPrivilegios = new HashSet<PublicadorPrivilegios>();
      ServicoCampo = new HashSet<ServicoCampo>();
      ServicoCampod = new HashSet<ServicoCampod>();
      ServicoCampos = new HashSet<ServicoCampos>();
      ServicoCampot = new HashSet<ServicoCampot>();
      Transferencia = new HashSet<Transferencia>();
    }

    public long Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string Ipaddress { get; set; }
    public long AuditoriaUsuario { get; set; }
    public string Bairro { get; set; }
    public DateTime? Batismo { get; set; }
    public string Cep { get; set; }
    public bool ChefeFamilia { get; set; }
    public string Cidade { get; set; }
    public string Complemento { get; set; }
    public DateTime? DataAnciao { get; set; }
    public DateTime? DataInativo { get; set; }
    public DateTime? DataInicioServico { get; set; }
    public DateTime? DataNascimento { get; set; }
    public DateTime? DataReativado { get; set; }
    public DateTime? DataServoMinisterial { get; set; }
    public long? DianteiraId { get; set; }
    public string Email { get; set; }
    public long? EstadoId { get; set; }
    public long CountryId { get; set; }
    public Country Country { get; set; }
    public long? GrupoId { get; set; }
    public bool IrmaoBatizado { get; set; }
    public string Login { get; set; }
    public string Nome { get; set; }
    public string Anointed { get; set; }
    public string NomeLogradouro { get; set; }
    public string Observacao { get; set; }
    public string Perfil { get; set; }
    public long? PioneiroId { get; set; }
    public string Senha { get; set; }
    public string Sexo { get; set; }
    public long SituacaoId { get; set; }
    public string SituacaoServicoCampo { get; set; }
    public string TelCelular { get; set; }
    public string TelResidencial { get; set; }
    public string TelTrabalho { get; set; }
    public long? TipoLogradouroId { get; set; }
    public DateTime? InicioPioneiro { get; set; }
    public string NumeroPioneiro { get; set; }
    public long CongregacaoId { get; set; }

    public Congregacao Congregacao { get; set; }
    public Dianteira Dianteira { get; set; }
    public Estado Estado { get; set; }
    public Grupo Grupo { get; set; }
    public Pioneiro Pioneiro { get; set; }
    public Situacao Situacao { get; set; }
    public TipoLogradouro TipoLogradouro { get; set; }
    // public Boolean Professes { get; set; }
    public ICollection<Familia> FamiliaChefeFamilia { get; set; }
    public ICollection<Familia> FamiliaMembro { get; set; }
    public ICollection<Familiares> FamiliaresMembro { get; set; }
    public ICollection<Familiares> FamiliaresPublicador { get; set; }
    public ICollection<Grupo> GrupoAjudante { get; set; }
    public ICollection<Grupo> GrupoSuperintendente { get; set; }
    public ICollection<PeticaoPioneiroAuxiliar> PeticaoPioneiroAuxiliar { get; set; }
    public ICollection<PublicadorHistorico> PublicadorHistorico { get; set; }
    public ICollection<PublicadorPrivilegios> PublicadorPrivilegios { get; set; }
    public ICollection<ServicoCampo> ServicoCampo { get; set; }
    public ICollection<ServicoCampod> ServicoCampod { get; set; }
    public ICollection<ServicoCampos> ServicoCampos { get; set; }
    public ICollection<ServicoCampot> ServicoCampot { get; set; }
    public ICollection<Transferencia> Transferencia { get; set; }
  }
}
