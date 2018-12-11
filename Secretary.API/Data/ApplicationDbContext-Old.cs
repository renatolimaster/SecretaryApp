using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Model;

namespace Secretary.API.Data
{
    public class ApplicationDbContextOld : DbContext
    {
        public ApplicationDbContextOld(DbContextOptions<ApplicationDbContextOld> options) : base(options) { }

        public virtual DbSet<AssistenciaReuniao> AssistenciaReuniao { get; set; }
        public virtual DbSet<Congregacao> Congregacao { get; set; }
        public virtual DbSet<Dianteira> Dianteira { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Familiares> Familiares { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.HasDefaultSchema("secretary");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "secretary");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('secretary.\"Country_Id_seq\"'::regclass)");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("now()");

                entity.Property(e => e.IPAddress).HasColumnName("IPAddress");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Iso).HasColumnName("Iso");
                entity.Property(e => e.Iso).HasColumnName("Iso");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.NiceName).HasColumnName("NiceName");
                entity.Property(e => e.Iso3).HasColumnName("Iso3");
                entity.Property(e => e.NumCode).HasColumnName("NumCode");
                entity.Property(e => e.PhoneCode).HasColumnName("PhoneCode");


            });

            modelBuilder.Entity<AssistenciaReuniao>(entity =>
            {
                entity.ToTable("AssistenciaReuniao", "secretary");

                entity.HasIndex(e => e.ReuniaoId)
                    .HasName("FK_AssistenciaReuniao_Reuniao");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_AssistenciaReuniao_Congregacao");

                entity.Property(e => e.DataReferencia)
                    .HasColumnType("TIMESTAMP(3)");


                entity.HasOne(d => d.Reuniao)
                    .WithMany(p => p.AssistenciaReuniao)
                    .HasForeignKey(d => d.ReuniaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AssistenciaReuniao$FK_AssistenciaReuniao_Reuniao");
                /*
                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.AssistenciaReuniao)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AssistenciaReuniao$FK_AssistenciaReuniao_Congregacao");
                     */
            });

            modelBuilder.Entity<Congregacao>(entity =>
            {
                entity.ToTable("Congregacao", "secretary");

                entity.HasIndex(e => e.EstadoId)
                    .HasName("FK_Congregacao_Estado");

                entity.HasIndex(e => e.TipoLogradouroId)
                    .HasName("FK_Congregacao_TipoLogradouro");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255);

                entity.Property(e => e.Cep)
                    .HasMaxLength(255);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255);

                entity.Property(e => e.Coordenador)
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(255);

                entity.Property(e => e.EstadoId);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NomeLogradouro)
                    .HasMaxLength(255);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255);

                entity.Property(e => e.Padrao)
                    .IsRequired()
                    .HasColumnType("boolean");

                entity.Property(e => e.TelCelular)
                    .HasMaxLength(255);

                entity.Property(e => e.TelResidencial)
                    .HasMaxLength(255);

                entity.Property(e => e.TelTrabalho)
                    .HasMaxLength(255);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(255);
                /*
                                entity.HasOne(p => p.Estado)
                                    .WithMany(e => e.Congregacao)
                                    .HasForeignKey(e => e.EstadoId)
                                    .HasConstraintName("congregacao$FK_Estado")
                                    .OnDelete(DeleteBehavior.Cascade);

                                entity.HasOne(p => p.TipoLogradouro)
                                    .WithMany(e => e.Congregacao)
                                    .HasForeignKey(e => e.TipoLogradouroId)
                                    .HasConstraintName("congregacao$FK_TipoLogradouro")
                                    .OnDelete(DeleteBehavior.Cascade);
                 */
            });


            modelBuilder.Entity<Dianteira>(entity =>
            {
                entity.ToTable("Dianteira", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Dianteira_Congregacao");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(e => e.Congregacao)
                    .WithMany(e => e.Dianteira)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Dianteira$FK_Dianteira_Congregacao");
            });


            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado", "secretary");

                entity.HasIndex(e => e.CountryId)
                .HasName("FK_Estado_Country");

                entity.Property(e => e.AuditoriaUsuario)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Estado)
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

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

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
                    .OnDelete(DeleteBehavior.Cascade)
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

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(255);

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasMaxLength(20);

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

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Familiares)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("familia$FK_Familiares_Congregacao");
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

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Ajudante)
                    .WithMany(p => p.GrupoAjudante)
                    .HasForeignKey(d => d.AjudanteId)
                    .HasConstraintName("grupo$FK_Grupo_Ajudante");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("grupo$FK_Grupo_Congregacao");

                entity.HasOne(d => d.Superintendente)
                    .WithMany(p => p.GrupoSuperintendente)
                    .HasForeignKey(d => d.SuperintendenteId)
                    .HasConstraintName("grupo$FK_Grupo_Superintendente");
            });

            modelBuilder.Entity<Pioneiro>(entity =>
            {
                entity.ToTable("Pioneiro", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Pioneiro_Congregacao");

                entity.Property(e => e.AuditoriaUsuario)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Pioneiro)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("grupo$FK_Pioneiro_Congregacao");
            });

            modelBuilder.Entity<PrivilegioCongregacional>(entity =>
            {
                entity.ToTable("PrivilegioCongregacional", "secretary");


                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_PrivilegioCongregacional_Congregacao");

                entity.Property(e => e.AuditoriaUsuario)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(255);

            });

            modelBuilder.Entity<Publicador>(entity =>
            {
                entity.ToTable("Publicador", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Publicador_Congregacao");

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

                entity.Property(e => e.CountryId).HasDefaultValueSql("30");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255);

                entity.Property(e => e.Batismo)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Cep)
                    .HasMaxLength(255);

                entity.Property(e => e.ChefeFamilia)
                    .IsRequired()
                    .HasColumnType("boolean")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255);

                entity.Property(e => e.DataAnciao)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DataInativo)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DataInicioServico)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DataReativado)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DataServoMinisterial)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");


                entity.Property(e => e.Email)
                    .HasMaxLength(255);

                entity.Property(e => e.InicioPioneiro)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.IrmaoBatizado)
                    .IsRequired()
                    .HasColumnType("boolean")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Login)
                    .HasMaxLength(255);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NomeLogradouro)
                    .HasMaxLength(255);

                entity.Property(e => e.NumeroPioneiro)
                    .HasMaxLength(255);

                entity.Property(e => e.Perfil)
                    .HasMaxLength(255);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(255);

                entity.Property(e => e.SituacaoServicoCampo)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.TelCelular)
                    .HasMaxLength(255);

                entity.Property(e => e.TelResidencial)
                    .HasMaxLength(255);

                entity.Property(e => e.TelTrabalho)
                    .HasMaxLength(255);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
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
                /*
                entity.HasOne(d => d.TipoLogradouro)
                    .WithMany(p => p.Publicador)
                    .HasForeignKey(d => d.TipoLogradouroId)
                    .HasConstraintName("publicador$FK_Publicador_TipoLogradouro");
                     */

                entity.HasIndex(e => e.CountryId)
                    .HasName("FK_Publicador_Country");
            });

            modelBuilder.Entity<PublicadorHistorico>(entity =>
            {
                entity.ToTable("PublicadorHistorico", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PublicadorHistorico_Publicador");

                entity.Property(e => e.DataReferencia)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Evento)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.PublicadorHistorico)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("publicador_historico$FK_PublicadorHistorico_Publicador");
            });

            modelBuilder.Entity<PublicadorPrivilegios>(entity =>
            {
                entity.ToTable("PublicadorPrivilegios", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PublicadorPrivilegios_Publicador");

                entity.HasIndex(e => new { e.PrivilegioCongregacionalId, e.PublicadorId })
                    .HasName("FK_PublicadorPrivilegios_PrivilegioCongregacional");

                entity.HasOne(d => d.PrivilegioCongregacional)
                    .WithMany(p => p.PublicadorPrivilegios)
                    .HasForeignKey(d => d.PrivilegioCongregacionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publicador_privilegios$FK_PublicadorPrivilegios_PrivilegioCongregacional");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.PublicadorPrivilegios)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publicador_privilegios$FK_PublicadorPrivilegios_Publicador");
            });

            modelBuilder.Entity<PublicadorUsuario>(entity =>
            {
                entity.ToTable("PublicadorUsuario", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PublicadorUsuario_Publicador");

                entity.HasIndex(e => e.UsuarioId)
                     .HasName("usuario_id");

                entity.Property(e => e.PublicadorId)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UsuarioId)
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Recibo>(entity =>
            {
                entity.ToTable("Recibo", "secretary");

                entity.HasIndex(e => e.ReuniaoId)
                    .HasName("FK_Recibo_Reuniao");


                entity.Property(e => e.Data)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(37);

                entity.Property(e => e.OutroDestino)
                    .HasMaxLength(255);

                entity.HasOne(d => d.Reuniao)
                    .WithMany(p => p.Recibo)
                    .HasForeignKey(d => d.ReuniaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("recibo$FK_Recibo_Reuniao");
            });

            modelBuilder.Entity<Reuniao>(entity =>
            {
                entity.ToTable("Reuniao", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Reuniao_Congregacao");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hora)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.Reuniao)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
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

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId, e.DataReferencia })
                .HasName("FK_ServicoCampo_Congregacao_Publicador_DataReferencia").IsUnique();


                entity.Property(e => e.CreditoHoras)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataEntrega)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DataReferencia)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Estudos)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FolhetosBrochuras)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Horas)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HorasBetel)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Livros)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Minutos)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Publicacoes)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Revisitas)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Revistas)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VideosMostrados)
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Congregacao)
                    .WithMany(p => p.ServicoCampo)
                    .HasForeignKey(d => d.CongregacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("servico_campo$FK_ServicoCampo_Congregacao");

                entity.HasOne(d => d.Pioneiro)
                    .WithMany(p => p.ServicoCampo)
                    .HasForeignKey(d => d.PioneiroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("servico_campo$FK_ServicoCampo_Pioneiro");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampo)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("servico_campo$FK_ServicoCampo_Publicador");
            });

            modelBuilder.Entity<ServicoCampod>(entity =>
            {
                entity.ToTable("ServicoCampod", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampod_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                .HasName("FK_ServicoCampod_Congregacao_Publicador");

                entity.Property(e => e.VideosMostrados).HasColumnName("videos_mostrados");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampod)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("servico_campod$FK_ServicoCampod_Publicador");
            });

            modelBuilder.Entity<ServicoCampos>(entity =>
            {
                entity.ToTable("ServicoCampos", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampos_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("FK_ServicoCampos_Congregacao_Publicador");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampos)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("servico_campos$FK_ServicoCampos_Publicador");
            });

            modelBuilder.Entity<ServicoCampot>(entity =>
            {
                entity.ToTable("ServicoCampot", "secretary");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_ServicoCampot_Publicador");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                .HasName("FK_ServicoCampot_Congregacao_Publicador");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.ServicoCampot)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("servico_campot$FK_ServicoCampot_Publicador");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.ToTable("Situacao", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_Situacao_Congregacao");

                entity.HasIndex(e => e.Descricao)
                    .HasName("IX_Situacao_Descricao");

                entity.Property(e => e.AuditoriaUsuario)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TipoLogradouro>(entity =>
            {
                entity.ToTable("TipoLogradouro", "secretary");

                entity.HasIndex(e => e.Descricao)
                    .HasName("IX_Descricao");

                entity.Property(e => e.AuditoriaUsuario)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.ToTable("Transferencia", "secretary");

                entity.HasIndex(e => e.DestinoId)
                    .HasName("FK_TipoLogradouro_Destino");

                entity.HasIndex(e => e.OrigemId)
                    .HasName("FK_TipoLogradouro_Origem");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_TipoLogradouro_Publicador");

                entity.Property(e => e.Data)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("TIMESTAMP(3)");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasMaxLength(255);


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

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("IX_Usuario_Publicador");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_Usuario_Username")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Usuario_Email");

                entity.HasIndex(e => new { e.CongregacaoId, e.PublicadorId })
                    .HasName("IX_Usuario_Congregacao_Publicador");

                entity.Property(e => e.PasswordHarsh)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PublicadorId)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("usuario$IX_Usuario_Publicador");
            });

            modelBuilder.Entity<PeticaoPioneiroAuxiliar>(entity =>
            {
                entity.ToTable("PeticaoPioneiroAuxiliar", "secretary");

                entity.HasIndex(e => e.CongregacaoId)
                    .HasName("FK_PeticaoPioneiroAuxiliar_Congregacao");

                entity.HasIndex(e => e.PublicadorId)
                    .HasName("FK_PeticaoPioneiroAuxiliar_Publicador");

                entity.HasIndex(e => e.PioneiroId)
                    .HasName("FK_PeticaoPioneiroAuxiliar_Pioneiro");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(255);

                entity.Property(e => e.EstaAprovado)
                    .IsRequired()
                    .HasColumnType("boolean")
                    .HasDefaultValueSql("FALSE");

                entity.HasOne(d => d.Publicador)
                    .WithMany(p => p.PeticaoPioneiroAuxiliar)
                    .HasForeignKey(d => d.PublicadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("peticao$FK_PeticaoPioneiroAuxiliar_Publicador");
            });


        }

    }
}
