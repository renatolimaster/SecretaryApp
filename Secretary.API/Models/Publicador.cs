using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Models
{
    public partial class Publicador : BaseEntity
    {
        public Publicador()
        {
            FamiliaChefeFamilia = new HashSet<Familia>();
            FamiliaMembro = new HashSet<Familia>();
            FamiliaresMembro = new HashSet<Familiares>();
            FamiliaresPublicador = new HashSet<Familiares>();
            GrupoAjudante = new HashSet<Grupo>();
            GrupoSuperintendente = new HashSet<Grupo>();
            PublicadorHistorico = new HashSet<PublicadorHistorico>();
            PublicadorPrivilegios = new HashSet<PublicadorPrivilegios>();
            ServicoCampo = new HashSet<ServicoCampo>();
            ServicoCampod = new HashSet<ServicoCampod>();
            ServicoCampos = new HashSet<ServicoCampos>();
            ServicoCampot = new HashSet<ServicoCampot>();
            Transferencia = new HashSet<Transferencia>();
            Usuario = new HashSet<Usuario>();
        }

        
        
        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        [Display(Name = "Neighborhood")]
        public string Bairro { get; set; }
        [Display(Name = "Baptism")]
        [DataType(DataType.Date)]
        public DateTime? Batismo { get; set; }
        [Display(Name = "Zip Code")]
        public string Cep { get; set; }
        [Display(Name = "Householder")]
        [UIHint("YesNo")]
        public bool? ChefeFamilia { get; set; }
        [Display(Name = "City")]
        public string Cidade { get; set; }
        [Display(Name = "Complement")]
        public string Complemento { get; set; }
        
        [Display(Name = "Elder")]
        [DataType(DataType.Date)]
        public DateTime? DataAnciao { get; set; }
        [Display(Name = "Inactive")]
        [DataType(DataType.Date)]
        public DateTime? DataInativo { get; set; }
        [Display(Name = "Start Service")]
        [DataType(DataType.Date)]
        public DateTime? DataInicioServico { get; set; }
        [Display(Name = "Birth")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        [Display(Name = "Reactivate")]
        [DataType(DataType.Date)]
        public DateTime? DataReativado { get; set; }
        [Display(Name = "Servant")]
        [DataType(DataType.Date)]
        public DateTime? DataServoMinisterial { get; set; }
        
        [Display(Name = "Lead")]
        public long? DianteiraId { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = "fsr.vec@gmail.com";
        [Display(Name = "State")]
        public long? EstadoId { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Display(Name = "Group")]
        public long? GrupoId { get; set; }
        [Display(Name = "Is baptized")]
        [UIHint("YesNo")]
        public bool? IrmaoBatizado { get; set; }
        public string Login { get; set; }
        [Display(Name = "Name")]
        public string Nome { get; set; }

        public override string ToString()
        {
            string[] nome = Nome.Split(" ");
            return nome[0] + " " + nome[nome.Length - 1];
        }

        [Display(Name = "Street")]
        public string NomeLogradouro { get; set; }
        [Display(Name = "Obs")]
        public string Observacao { get; set; }
        public string Perfil { get; set; }
        [Display(Name = "Pioneer")]
        public long? PioneiroId { get; set; }
        [Display(Name = "Password")]
        public string Senha { get; set; }
        [Display(Name = "Gender")]
        public string Sexo { get; set; }
        public long SituacaoId { get; set; }
        [Display(Name = "Status Service")]
        public string SituacaoServicoCampo { get; set; }
        [Display(Name = "Cell Phone")]
        public string TelCelular { get; set; }
        [Display(Name = "Home Phone")]
        public string TelResidencial { get; set; }
        [Display(Name = "Job Phone")]
        public string TelTrabalho { get; set; }
        [Display(Name = "Type")]
        public long? TipoLogradouroId { get; set; }
        [Display(Name = "Start Pioneer")]
        [DataType(DataType.Date)]
        public DateTime? InicioPioneiro { get; set; }
        [Display(Name = "Pioneer Number")]
        public string NumeroPioneiro { get; set; }
        
        [Display(Name = "Privilege")]
        public Dianteira Dianteira { get; set; }
        [Display(Name = "State")]
        public Estado Estado { get; set; }
        [Display(Name = "Group")]
        public Grupo Grupo { get; set; }
        [Display(Name = "Pioneer")]
        public Pioneiro Pioneiro { get; set; }
        [Display(Name = "Status")]
        public Situacao Situacao { get; set; }
        [Display(Name = "Type")]
        public TipoLogradouro TipoLogradouro { get; set; }



        // Foreign Key

        [Display(Name = "Congregation")]
        public long CongregacaoId { get; set; }
        [Display(Name = "Congregation")]
        public Congregacao Congregacao { get; set; }


        // Collections
        public ICollection<Familia> FamiliaChefeFamilia { get; set; }
        public ICollection<Familia> FamiliaMembro { get; set; }
        public ICollection<Familiares> FamiliaresMembro { get; set; }
        public ICollection<Familiares> FamiliaresPublicador { get; set; }
        public ICollection<Grupo> GrupoAjudante { get; set; }
        public ICollection<Grupo> GrupoSuperintendente { get; set; }
        public ICollection<PublicadorHistorico> PublicadorHistorico { get; set; }
        public ICollection<PublicadorPrivilegios> PublicadorPrivilegios { get; set; }
        public ICollection<ServicoCampo> ServicoCampo { get; set; }
        public ICollection<ServicoCampod> ServicoCampod { get; set; }
        public ICollection<ServicoCampos> ServicoCampos { get; set; }
        public ICollection<ServicoCampot> ServicoCampot { get; set; }
        public ICollection<Transferencia> Transferencia { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<PeticaoPioneiroAuxiliar> PeticaoPioneiroAuxiliar { get; set; }
    }
}
