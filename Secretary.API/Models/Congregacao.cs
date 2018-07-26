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

        
        [Display(Name = "User")]
        public long AuditoriaUsuario { get; set; }
        [Display(Name = "Neighborhood")]
        public string Bairro { get; set; }
        [Display(Name = "Zip code")]
        public string Cep { get; set; }
        [Display(Name = "City")]
        public string Cidade { get; set; }
        [Display(Name = "Complement")]
        public string Complemento { get; set; }
        [Display(Name = "Coordinator")]
        public string Coordenador { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public long? EstadoId { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "Name")]
        public string Nome { get; set; }
        [Display(Name = "Street")]
        public string NomeLogradouro { get; set; }
        [Display(Name = "Number")]
        public string Numero { get; set; }
        [Display(Name = "Default")]
        public bool Padrao { get; set; }
        [Display(Name = "Cell Phone")]
        public string TelCelular { get; set; }
        [Display(Name = "Phone Home")]
        public string TelResidencial { get; set; }
        [Display(Name = "Phone Job")]
        public string TelTrabalho { get; set; }
        [Display(Name = "Phone")]
        public string Telefone { get; set; }

        public long? TipoLogradouroId { get; set; }
        [Display(Name = "Street Type")]
        public TipoLogradouro TipoLogradouro { get; set; }

        [Display(Name = "State")]
        public Estado Estado { get; set; }

        // Collections

        [Display(Name = "Assistence")]
        public ICollection<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        
        [Display(Name = "Leads")]
        public ICollection<Dianteira> Dianteira { get; set; }

        [Display(Name = "Parent")]
        public ICollection<Familia> Familia { get; set; }

        [Display(Name = "Parents")]
        public ICollection<Familiares> Familiares { get; set; }

        [Display(Name = "Group")]
        public ICollection<Grupo> Grupo { get; set; }

        [Display(Name = "Publisher")]
        public ICollection<Publicador> Publicador { get; set; }

        [Display(Name = "Meeting")]
        public ICollection<Reuniao> Reuniao { get; set; }

        [Display(Name = "Field Service")]
        public ICollection<ServicoCampo> ServicoCampo { get; set; }

        [Display(Name = "Field Service Media 12")]
        public ICollection<ServicoCampod> ServicoCampod { get; set; }

        [Display(Name = "Field Service Media 6")]
        public ICollection<ServicoCampos> ServicoCampos { get; set; }

        [Display(Name = "Field Service Media 3")]
        public ICollection<ServicoCampot> ServicoCampot { get; set; }

        [Display(Name = "Destination")]
        public ICollection<Transferencia> TransferenciaDestino { get; set; }

        [Display(Name = "Origen")]
        public ICollection<Transferencia> TransferenciaOrigem { get; set; }        
        [Display(Name = "Pioneer")]
        public ICollection<Pioneiro> Pioneiro { get; set; }

        [Display(Name = "Privilege")]
        public ICollection<PrivilegioCongregacional> PrivilegioCongregacional { get; set; }        

        [Display(Name = "Status")]
        public ICollection<Situacao> Situacao { get; set; }        

        public override string ToString()
        {
            return Nome + ":" + Numero;
        }
    }
}
