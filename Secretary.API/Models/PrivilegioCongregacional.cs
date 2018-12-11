using System;
using System.Collections.Generic;

namespace Secretary.API.Model
{
    public partial class PrivilegioCongregacional
    {
        public PrivilegioCongregacional()
        {
            PublicadorPrivilegios = new HashSet<PublicadorPrivilegios>();
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
        public long AuditoriaUsuario { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public long CongregacaoId { get; set; }

        public Congregacao Congregacao { get; set; }
        public ICollection<PublicadorPrivilegios> PublicadorPrivilegios { get; set; }
    }
}
