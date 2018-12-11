using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Secretary.API.Model
{
    public partial class secretaryContext : DbContext
    {
        public secretaryContext()
        {
        }

        public secretaryContext(DbContextOptions<secretaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        public virtual DbSet<Congregacao> Congregacao { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Dianteira> Dianteira { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Familiares> Familiares { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<PeticaoPioneiroAuxiliar> PeticaoPioneiroAuxiliar { get; set; }
        public virtual DbSet<Pioneiro> Pioneiro { get; set; }
        public virtual DbSet<PrivilegioCongregacional> PrivilegioCongregacional { get; set; }
        public virtual DbSet<Publicador> Publicador { get; set; }
        public virtual DbSet<PublicadorHistorico> PublicadorHistorico { get; set; }
        public virtual DbSet<PublicadorPrivilegios> PublicadorPrivilegios { get; set; }
        public virtual DbSet<PublicadorUsuario> PublicadorUsuario { get; set; }
        public virtual DbSet<Recibo> Recibo { get; set; }
        public virtual DbSet<Reuniao> Reuniao { get; set; }
        public virtual DbSet<ServicoCampo> ServicoCampo { get; set; }
        public virtual DbSet<ServicoCampod> ServicoCampod { get; set; }
        public virtual DbSet<ServicoCampos> ServicoCampos { get; set; }
        public virtual DbSet<ServicoCampot> ServicoCampot { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<TipoLogradouro> TipoLogradouro { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=secretary;Username=postgres;Password=22113311");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssistenciaReuniao>(entity =>
            {
                entity.ToTable("AssistenciaReuniao", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_AssistenciaReuniao_Congregacao");

                entity.HasIndex(e => e.ReuniaoId)
                    .HasName("FK_AssistenciaReuniao_Reuniao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"AssistenciaReuniao_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DataReferencia)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.ReuniaoId).HasDefaultValueSql("1");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.AssistenciaReuniao)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Reuniao)
                    .WithMany(p => p.AssistenciaReuniao)
                    .HasForeignKey(d => d.ReuniaoId)
                    .HasConstraintName("AssistenciaReuniao$FK_AssistenciaReuniao_Reuniao");
            });

            modelBuilder.Entity<Congregacao>(entity =>
            {
                entity.ToTable("Congregacao", "secretary");

                entity.HasIndex(e => e.EstadoId)
                    .HasName("FK_Congregacao_Estado");

                entity.HasIndex(e => e.TipoLogradouroId)
                    .HasName("FK_Congregacao_TipoLogradouro");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Congregacao_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.Bairro).HasMaxLength(255);

                entity.Property(e => e.Cep).HasMaxLength(255);

                entity.Property(e => e.Cidade).HasMaxLength(255);

                entity.Property(e => e.Complemento).HasMaxLength(255);

                entity.Property(e => e.Coordenador).HasMaxLength(255);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NomeLogradouro).HasMaxLength(255);

                entity.Property(e => e.Numero).HasMaxLength(255);

                entity.Property(e => e.TelCelular).HasMaxLength(255);

                entity.Property(e => e.TelResidencial).HasMaxLength(255);

                entity.Property(e => e.TelTrabalho).HasMaxLength(255);

                entity.Property(e => e.Telefone).HasMaxLength(255);

                entity.HasOne(d => d.TipoLogradouro)
                    .WithMany(p => p.Congregacao)
                    .HasForeignKey(d => d.TipoLogradouroId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "secretary");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Country_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.IPAddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Dianteira>(entity =>
            {
                entity.ToTable("Dianteira", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Dianteira_Congregacao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Dianteira_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Dianteira)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("Dianteira$FK_Dianteira_Congregacao");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado", "secretary");

                entity.HasIndex(e => e.CountryId)
                    .HasName("FK_Estado_Country");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Estado_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Dianteira$FK_Estado_Country");
            });

            modelBuilder.Entity<Familia>(entity =>
            {
                entity.ToTable("Familia", "secretary");

                entity.HasIndex(e => e.ChefeFamiliaId)
                    .HasName("FK_Familia_ChefeFamilia");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Familia_Congregacao");

                entity.HasIndex(e => e.MembroId)
                    .HasName("FK_Membro");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Familia_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.ChefeFamilia)
                    .WithMany(p => p.FamiliaChefeFamilia)
                    .HasForeignKey(d => d.ChefeFamiliaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("familia$FK_Familia_ChefeFamilia");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("familia$FK_Familia_Congregacao");

                entity.HasOne(d => d.Membro)
                    .WithMany(p => p.FamiliaMembro)
                    .HasForeignKey(d => d.MembroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("familia$FK_Familia_Membro");
            });

            modelBuilder.Entity<Familiares>(entity =>
            {
                entity.ToTable("Familiares", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Familiares_Congregacao");

                entity.HasIndex(e => e.MembroId)
                    .HasName("FK_Familiares_Membro");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_Familiares_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Familiares_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Observacao).HasMaxLength(255);

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Familiares)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("familia$FK_Familiares_Congregacao");

                entity.HasOne(d => d.Membro)
                    .WithMany(p => p.FamiliaresMembro)
                    .HasForeignKey(d => d.MembroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("familiares$FK_Familiares_Membro");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.FamiliaresPublicador)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("familiares$FK_Familiares_Publicador");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("Grupo", "secretary");

                entity.HasIndex(e => e.AjudanteId)
                    .HasName("FK_Grupo_Ajudante");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Grupo_Congregacao");

                entity.HasIndex(e => e.SuperintendenteId)
                    .HasName("FK_Grupo_Superintendente");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Grupo_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Ajudante)
                    .WithMany(p => p.GrupoAjudante)
                    .HasForeignKey(d => d.AjudanteId)
                    .HasConstraintName("grupo$FK_Grupo_Ajudante");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("grupo$FK_Grupo_Congregacao");

                entity.HasOne(d => d.Superintendente)
                    .WithMany(p => p.GrupoSuperintendente)
                    .HasForeignKey(d => d.SuperintendenteId)
                    .HasConstraintName("grupo$FK_Grupo_Superintendente");
            });

            modelBuilder.Entity<PeticaoPioneiroAuxiliar>(entity =>
            {
                entity.ToTable("PeticaoPioneiroAuxiliar", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_PeticaoPioneiroAuxiliar_Congregacao");

                entity.HasIndex(e => e.PioneiroId)
                    .HasName("FK_PeticaoPioneiroAuxiliar_Pioneiro");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PeticaoPioneiroAuxiliar_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"PeticaoPioneiroAuxiliar_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Observacao).HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.PeticaoPioneiroAuxiliar)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Pioneiro)
                    .WithMany(p => p.PeticaoPioneiroAuxiliar)
                    .HasForeignKey(d => d.PioneiroId);

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.PeticaoPioneiroAuxiliar)
                    .HasForeignKey(d => d.PublicadorId)
                    .HasConstraintName("peticao$FK_PeticaoPioneiroAuxiliar_Publicador");
            });

            modelBuilder.Entity<Pioneiro>(entity =>
            {
                entity.ToTable("Pioneiro", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Pioneiro_Congregacao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Pioneiro_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Observacao).HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Pioneiro)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("grupo$FK_Pioneiro_Congregacao");
            });

            modelBuilder.Entity<PrivilegioCongregacional>(entity =>
            {
                entity.ToTable("PrivilegioCongregacional", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_PrivilegioCongregacional_Congregacao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"PrivilegioCongregacional_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Observacao).HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.PrivilegioCongregacional)
                    .HasForeignKey(d => d.CongregacaoId);
            });

            modelBuilder.Entity<Publicador>(entity =>
            {
                entity.ToTable("Publicador", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Publicador_Congregacao");

                entity.HasIndex(e => e.CountryId)
                    .HasName("publicador$FK_Publicador_Country");

                entity.HasIndex(e => e.DianteiraId)
                    .HasName("FK_Publicador_Dianteira");

                entity.HasIndex(e => e.EstadoId)
                    .HasName("FK_Publicador_Estado");

                entity.HasIndex(e => e.GrupoId)
                    .HasName("FK__PublicadorGrupo");

                entity.HasIndex(e => e.PioneiroId)
                    .HasName("FK_Publicador_Pioneiro");

                entity.HasIndex(e => e.SituacaoId)
                    .HasName("FK_Publicador_Situacao");

                entity.HasIndex(e => e.TipoLogradouroId)
                    .HasName("FK_Publicador_TipoLogradouro");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Publicador_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.Bairro).HasMaxLength(255);

                entity.Property(e => e.Batismo).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.Cep).HasMaxLength(255);

                entity.Property(e => e.Cidade).HasMaxLength(255);

                entity.Property(e => e.Complemento).HasMaxLength(255);

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.CountryId).HasDefaultValueSql("30");

                entity.Property(e => e.DataAnciao).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DataInativo).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DataInicioServico).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DataNascimento).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DataReativado).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DataServoMinisterial).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.InicioPioneiro).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NomeLogradouro).HasMaxLength(255);

                entity.Property(e => e.NumeroPioneiro).HasMaxLength(255);

                entity.Property(e => e.Perfil).HasMaxLength(255);

                entity.Property(e => e.Senha).HasMaxLength(255);

                entity.Property(e => e.Sexo).HasMaxLength(255);

                entity.Property(e => e.SituacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.SituacaoServicoCampo)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'Irregular'::character varying");

                entity.Property(e => e.TelCelular).HasMaxLength(255);

                entity.Property(e => e.TelResidencial).HasMaxLength(255);

                entity.Property(e => e.TelTrabalho).HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("publicador$FK_Publicador_Congregacao");

                entity.HasOne(d => d.Dianteira)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.DianteiraId)
                    .HasConstraintName("publicador$FK_Publicador_Dianteira");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("publicador$FK_Publicador_Estado");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("publicador$FK_Publicador_Grupo");

                entity.HasOne(d => d.Pioneiro)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.PioneiroId)
                    .HasConstraintName("publicador$FK_Publicador_Pioneiro");

                entity.HasOne(d => d.Situacao)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.SituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publicador$FK_Publicador_Situacao");

                entity.HasOne(d => d.TipoLogradouro)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.TipoLogradouroId)
                    .HasConstraintName("publicador$FK_Publicador_TipoLogradouro");
            });

            modelBuilder.Entity<PublicadorHistorico>(entity =>
            {
                entity.ToTable("PublicadorHistorico", "secretary");

                entity.HasIndex(e => e.CongregacaoId);

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PublicadorHistorico_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"PublicadorHistorico_Id_seq\"'::regclass)");

                entity.Property(e => e.DataReferencia).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Evento)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.PublicadorHistorico)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.PublicadorHistorico)
                    .HasForeignKey(d => d.PublicadorId)
                    .HasConstraintName("publicador_historico$FK_PublicadorHistorico_Publicador");
            });

            modelBuilder.Entity<PublicadorPrivilegios>(entity =>
            {
                entity.ToTable("PublicadorPrivilegios", "secretary");

                entity.HasIndex(e => e.CongregacaoId);

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PublicadorPrivilegios_Publicador");

                entity.HasIndex(e => new { e.PrivilegioCongregacionalId, e.PublicadorId })
                    .HasName("FK_PublicadorPrivilegios_PrivilegioCongregacional");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"PublicadorPrivilegios_Id_seq\"'::regclass)");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.PrivilegioCongregacionalId).HasDefaultValueSql("15");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("1");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.PublicadorPrivilegios)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.PrivilegioCongregacional)
                    .WithMany(p => p.PublicadorPrivilegios)
                    .HasForeignKey(d => d.PrivilegioCongregacionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publicador_privilegios$FK_PublicadorPrivilegios_PrivilegioCongr");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.PublicadorPrivilegios)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publicador_privilegios$FK_PublicadorPrivilegios_Publicador");
            });

            modelBuilder.Entity<PublicadorUsuario>(entity =>
            {
                entity.ToTable("PublicadorUsuario", "secretary");

                entity.HasIndex(e => e.CongregacaoId);

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PublicadorUsuario_Publicador");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("usuario_id");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"PublicadorUsuario_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.PublicadorUsuario)
                    .HasForeignKey(d => d.CongregacaoId);
            });

            modelBuilder.Entity<Recibo>(entity =>
            {
                entity.ToTable("Recibo", "secretary");

                entity.HasIndex(e => e.CongregacaoId);

                entity.HasIndex(e => e.ReuniaoId)
                    .HasName("FK_Recibo_Reuniao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Recibo_Id_seq\"'::regclass)");

                entity.Property(e => e.Data).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(37);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.OutroDestino).HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Recibo)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Reuniao)
                    .WithMany(p => p.Recibo)
                    .HasForeignKey(d => d.ReuniaoId)
                    .HasConstraintName("recibo$FK_Recibo_Reuniao");
            });

            modelBuilder.Entity<Reuniao>(entity =>
            {
                entity.ToTable("Reuniao", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Reuniao_Congregacao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Reuniao_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Hora)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Reuniao)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("reuniao$FK_Reuniao_Congregacao");
            });

            modelBuilder.Entity<ServicoCampo>(entity =>
            {
                entity.ToTable("ServicoCampo", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_ServicoCampo_Congregacao");

                entity.HasIndex(e => e.PioneiroId)
                    .HasName("FK_ServicoCampo_Pioneiro");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampo_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("FK_ServicoCampo_Congregacao_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"ServicoCampo_Id_seq\"'::regclass)");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DataEntrega)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DataReferencia)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Estudos).HasDefaultValueSql("0");

                entity.Property(e => e.FolhetosBrochuras).HasDefaultValueSql("0");

                entity.Property(e => e.Horas).HasDefaultValueSql("0");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.Livros).HasDefaultValueSql("0");

                entity.Property(e => e.Minutos).HasDefaultValueSql("0");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.PioneiroId).HasDefaultValueSql("1");

                entity.Property(e => e.Publicacoes).HasDefaultValueSql("0");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("1");

                entity.Property(e => e.Revisitas).HasDefaultValueSql("0");

                entity.Property(e => e.Revistas).HasDefaultValueSql("0");

                entity.Property(e => e.VideosMostrados).HasDefaultValueSql("0");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.ServicoCampo)
                    .HasForeignKey(d => d.CongregacaoId)
                    .HasConstraintName("servico_campo$FK_ServicoCampo_Congregacao");

                entity.HasOne(d => d.Pioneiro)
                    .WithMany(p => p.ServicoCampo)
                    .HasForeignKey(d => d.PioneiroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("servico_campo$FK_ServicoCampo_Pioneiro");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampo)
                    .HasForeignKey(d => d.PublicadorId)
                    .HasConstraintName("servico_campo$FK_ServicoCampo_Publicador");
            });

            modelBuilder.Entity<ServicoCampod>(entity =>
            {
                entity.ToTable("ServicoCampod", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampod_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("FK_ServicoCampod_Congregacao_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"ServicoCampod_Id_seq\"'::regclass)");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("1");

                entity.Property(e => e.VideosMostrados).HasColumnName("videos_mostrados");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.ServicoCampod)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampod)
                    .HasForeignKey(d => d.PublicadorId)
                    .HasConstraintName("servico_campod$FK_ServicoCampod_Publicador");
            });

            modelBuilder.Entity<ServicoCampos>(entity =>
            {
                entity.ToTable("ServicoCampos", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampos_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("FK_ServicoCampos_Congregacao_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"ServicoCampos_Id_seq\"'::regclass)");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("1");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.ServicoCampos)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampos)
                    .HasForeignKey(d => d.PublicadorId)
                    .HasConstraintName("servico_campos$FK_ServicoCampos_Publicador");
            });

            modelBuilder.Entity<ServicoCampot>(entity =>
            {
                entity.ToTable("ServicoCampot", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampot_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("FK_ServicoCampot_Congregacao_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"ServicoCampot_Id_seq\"'::regclass)");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("1");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.ServicoCampot)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampot)
                    .HasForeignKey(d => d.PublicadorId)
                    .HasConstraintName("servico_campot$FK_ServicoCampot_Publicador");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.ToTable("Situacao", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Situacao_Congregacao");

                entity.HasIndex(e => e.Descricao);

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Situacao_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Situacao)
                    .HasForeignKey(d => d.CongregacaoId);
            });

            modelBuilder.Entity<TipoLogradouro>(entity =>
            {
                entity.ToTable("TipoLogradouro", "secretary");

                entity.HasIndex(e => e.Descricao)
                    .HasName("IX_Descricao");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"TipoLogradouro_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.ToTable("Transferencia", "secretary");

                entity.HasIndex(e => e.CongregacaoId);

                entity.HasIndex(e => e.DestinoId)
                    .HasName("FK_TipoLogradouro_Destino");

                entity.HasIndex(e => e.OrigemId)
                    .HasName("FK_TipoLogradouro_Origem");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_TipoLogradouro_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Transferencia_Id_seq\"'::regclass)");

                entity.Property(e => e.AuditoriaUsuario).HasDefaultValueSql("1");

                entity.Property(e => e.CongregacaoId).HasDefaultValueSql("1");

                entity.Property(e => e.Data).HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DestinoId).HasDefaultValueSql("1");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OrigemId).HasDefaultValueSql("1");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("1");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.TransferenciaCongregacao)
                    .HasForeignKey(d => d.CongregacaoId);

                entity.HasOne(d => d.Destino)
                    .WithMany(p => p.TransferenciaDestino)
                    .HasForeignKey(d => d.DestinoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transferencia$FK_TipoLogradouro_Destino");

                entity.HasOne(d => d.Origem)
                    .WithMany(p => p.TransferenciaOrigem)
                    .HasForeignKey(d => d.OrigemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transferencia$FK_TipoLogradouro_Origem");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.Transferencia)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transferencia$FK_TipoLogradouro_Publicador");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario", "secretary");

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Usuario_Email");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("IX_Usuario_Publicador");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_Usuario_Username")
                    .IsUnique();

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("IX_Usuario_Congregacao_Publicador");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"usuario_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.PasswordHarsh)
                    .IsRequired()
                    .HasDefaultValueSql("'\\x'::bytea");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasDefaultValueSql("'\\x'::bytea");

                entity.Property(e => e.PublicadorId).HasDefaultValueSql("0");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("0");
            });

            modelBuilder.HasSequence("AssistenciaReuniao_Id_seq");

            modelBuilder.HasSequence("Congregacao_Id_seq");

            modelBuilder.HasSequence("Country_Id_seq");

            modelBuilder.HasSequence("Dianteira_Id_seq");

            modelBuilder.HasSequence("Estado_Id_seq");

            modelBuilder.HasSequence("Familia_Id_seq");

            modelBuilder.HasSequence("Familiares_Id_seq");

            modelBuilder.HasSequence("Grupo_Id_seq");

            modelBuilder.HasSequence("PeticaoPioneiroAuxiliar_Id_seq");

            modelBuilder.HasSequence("Pioneiro_Id_seq");

            modelBuilder.HasSequence("PrivilegioCongregacional_Id_seq");

            modelBuilder.HasSequence("Publicador_Id_seq");

            modelBuilder.HasSequence("PublicadorHistorico_Id_seq");

            modelBuilder.HasSequence("PublicadorPrivilegios_Id_seq");

            modelBuilder.HasSequence("PublicadorUsuario_Id_seq");

            modelBuilder.HasSequence("Recibo_Id_seq");

            modelBuilder.HasSequence("Reuniao_Id_seq");

            modelBuilder.HasSequence("ServicoCampo_Id_seq");

            modelBuilder.HasSequence("ServicoCampod_Id_seq");

            modelBuilder.HasSequence("ServicoCampos_Id_seq");

            modelBuilder.HasSequence("ServicoCampot_Id_seq");

            modelBuilder.HasSequence("Situacao_Id_seq");

            modelBuilder.HasSequence("TipoLogradouro_Id_seq");

            modelBuilder.HasSequence("Transferencia_Id_seq");

            modelBuilder.HasSequence("usuario_Id_seq");
        }
    }
}
