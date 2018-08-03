using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Secretary.API.Migrations
{
    public partial class AfterCorrectionAndPeticao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "secretary");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    Iso = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NiceName = table.Column<string>(nullable: true),
                    Iso3 = table.Column<string>(nullable: true),
                    NumCode = table.Column<int>(nullable: true),
                    PhoneCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLogradouro",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false, defaultValueSql: "1"),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLogradouro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false, defaultValueSql: "1"),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    CountryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "Dianteira$FK_Estado_Country",
                        column: x => x.CountryId,
                        principalSchema: "secretary",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Congregacao",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 255, nullable: true),
                    Cep = table.Column<string>(maxLength: 255, nullable: true),
                    Cidade = table.Column<string>(maxLength: 255, nullable: true),
                    Complemento = table.Column<string>(maxLength: 255, nullable: true),
                    Coordenador = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    EstadoId = table.Column<long>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    NomeLogradouro = table.Column<string>(maxLength: 255, nullable: true),
                    Numero = table.Column<string>(maxLength: 255, nullable: true),
                    Padrao = table.Column<bool>(type: "boolean", nullable: false),
                    TelCelular = table.Column<string>(maxLength: 255, nullable: true),
                    TelResidencial = table.Column<string>(maxLength: 255, nullable: true),
                    TelTrabalho = table.Column<string>(maxLength: 255, nullable: true),
                    Telefone = table.Column<string>(maxLength: 255, nullable: true),
                    TipoLogradouroId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Congregacao_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "secretary",
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Congregacao_TipoLogradouro_TipoLogradouroId",
                        column: x => x.TipoLogradouroId,
                        principalSchema: "secretary",
                        principalTable: "TipoLogradouro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dianteira",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dianteira", x => x.Id);
                    table.ForeignKey(
                        name: "Dianteira$FK_Dianteira_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pioneiro",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false, defaultValueSql: "1"),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Observacao = table.Column<string>(maxLength: 255, nullable: true),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pioneiro", x => x.Id);
                    table.ForeignKey(
                        name: "grupo$FK_Pioneiro_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivilegioCongregacional",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false, defaultValueSql: "1"),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    Observacao = table.Column<string>(maxLength: 255, nullable: true),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilegioCongregacional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivilegioCongregacional_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicadorUsuario",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    PublicadorId = table.Column<long>(nullable: false, defaultValueSql: "0"),
                    UsuarioId = table.Column<long>(nullable: false, defaultValueSql: "0"),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicadorUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicadorUsuario_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reuniao",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    DiaSemana = table.Column<string>(maxLength: 50, nullable: false),
                    Hora = table.Column<string>(maxLength: 50, nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reuniao", x => x.Id);
                    table.ForeignKey(
                        name: "reuniao$FK_Reuniao_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Situacao",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false, defaultValueSql: "1"),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Situacao_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssistenciaReuniao",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AnoReferencia = table.Column<int>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    Media = table.Column<double>(nullable: true),
                    MesReferencia = table.Column<int>(nullable: true),
                    Semana1 = table.Column<int>(nullable: true),
                    Estrangeiros1 = table.Column<int>(nullable: true),
                    Semana2 = table.Column<int>(nullable: true),
                    Estrangeiros2 = table.Column<int>(nullable: true),
                    Semana3 = table.Column<int>(nullable: true),
                    Estrangeiros3 = table.Column<int>(nullable: true),
                    Semana4 = table.Column<int>(nullable: true),
                    Estrangeiros4 = table.Column<int>(nullable: true),
                    Semana5 = table.Column<int>(nullable: true),
                    Estrangeiros5 = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: true),
                    ReuniaoId = table.Column<long>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistenciaReuniao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistenciaReuniao_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "AssistenciaReuniao$FK_AssistenciaReuniao_Reuniao",
                        column: x => x.ReuniaoId,
                        principalSchema: "secretary",
                        principalTable: "Reuniao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recibo",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AnoMesReferencia = table.Column<int>(nullable: false),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    Destino = table.Column<string>(maxLength: 37, nullable: false),
                    OutroDestino = table.Column<string>(maxLength: 255, nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    ReuniaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibo_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "recibo$FK_Recibo_Reuniao",
                        column: x => x.ReuniaoId,
                        principalSchema: "secretary",
                        principalTable: "Reuniao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Parentesco = table.Column<string>(maxLength: 20, nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    ChefeFamiliaId = table.Column<long>(nullable: false),
                    MembroId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                    table.ForeignKey(
                        name: "familia$FK_Familia_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Familiares",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 255, nullable: true),
                    Parentesco = table.Column<string>(maxLength: 20, nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    MembroId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.Id);
                    table.ForeignKey(
                        name: "familia$FK_Familiares_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Local = table.Column<string>(maxLength: 255, nullable: false),
                    AjudanteId = table.Column<long>(nullable: true),
                    CongregacaoId = table.Column<long>(nullable: false),
                    SuperintendenteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                    table.ForeignKey(
                        name: "grupo$FK_Grupo_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicador",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 255, nullable: true),
                    Batismo = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    Cep = table.Column<string>(maxLength: 255, nullable: true),
                    ChefeFamilia = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "FALSE"),
                    Cidade = table.Column<string>(maxLength: 255, nullable: true),
                    Complemento = table.Column<string>(maxLength: 255, nullable: true),
                    DataAnciao = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    DataInativo = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    DataInicioServico = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    DataReativado = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    DataServoMinisterial = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    DianteiraId = table.Column<long>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    EstadoId = table.Column<long>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<long>(nullable: true),
                    IrmaoBatizado = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "FALSE"),
                    Login = table.Column<string>(maxLength: 255, nullable: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    NomeLogradouro = table.Column<string>(maxLength: 255, nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Perfil = table.Column<string>(maxLength: 255, nullable: true),
                    PioneiroId = table.Column<long>(nullable: true),
                    Senha = table.Column<string>(maxLength: 255, nullable: true),
                    Sexo = table.Column<string>(maxLength: 255, nullable: true),
                    SituacaoId = table.Column<long>(nullable: false),
                    SituacaoServicoCampo = table.Column<string>(maxLength: 9, nullable: false),
                    TelCelular = table.Column<string>(maxLength: 255, nullable: true),
                    TelResidencial = table.Column<string>(maxLength: 255, nullable: true),
                    TelTrabalho = table.Column<string>(maxLength: 255, nullable: true),
                    TipoLogradouroId = table.Column<long>(nullable: true),
                    InicioPioneiro = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    NumeroPioneiro = table.Column<string>(maxLength: 255, nullable: true),
                    CongregacaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicador", x => x.Id);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_Dianteira",
                        column: x => x.DianteiraId,
                        principalSchema: "secretary",
                        principalTable: "Dianteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_Estado",
                        column: x => x.EstadoId,
                        principalSchema: "secretary",
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_Grupo",
                        column: x => x.GrupoId,
                        principalSchema: "secretary",
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_Pioneiro",
                        column: x => x.PioneiroId,
                        principalSchema: "secretary",
                        principalTable: "Pioneiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_Situacao",
                        column: x => x.SituacaoId,
                        principalSchema: "secretary",
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "publicador$FK_Publicador_TipoLogradouro",
                        column: x => x.TipoLogradouroId,
                        principalSchema: "secretary",
                        principalTable: "TipoLogradouro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeticaoPioneiroAuxiliar",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    ReferenciaInicial = table.Column<DateTime>(nullable: false),
                    ReferenciaFinal = table.Column<DateTime>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false),
                    PioneiroId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeticaoPioneiroAuxiliar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeticaoPioneiroAuxiliar_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeticaoPioneiroAuxiliar_Pioneiro_PioneiroId",
                        column: x => x.PioneiroId,
                        principalSchema: "secretary",
                        principalTable: "Pioneiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "peticao$FK_PeticaoPioneiroAuxiliar_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicadorHistorico",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    DataReferencia = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    Evento = table.Column<string>(maxLength: 255, nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicadorHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicadorHistorico_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "publicador_historico$FK_PublicadorHistorico_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicadorPrivilegios",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    PrivilegioCongregacionalId = table.Column<long>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicadorPrivilegios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicadorPrivilegios_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "publicador_privilegios$FK_PublicadorPrivilegios_PrivilegioCongregacional",
                        column: x => x.PrivilegioCongregacionalId,
                        principalSchema: "secretary",
                        principalTable: "PrivilegioCongregacional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "publicador_privilegios$FK_PublicadorPrivilegios_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicoCampo",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AnoReferencia = table.Column<int>(nullable: true),
                    DataEntrega = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    Estudos = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    FolhetosBrochuras = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Horas = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Livros = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    MesReferencia = table.Column<int>(nullable: true),
                    Minutos = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Observacao = table.Column<string>(nullable: true),
                    PioneiroId = table.Column<long>(nullable: false),
                    Revisitas = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Revistas = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Publicacoes = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    VideosMostrados = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    HorasBetel = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    CreditoHoras = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoCampo", x => x.Id);
                    table.ForeignKey(
                        name: "servico_campo$FK_ServicoCampo_Congregacao",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "servico_campo$FK_ServicoCampo_Pioneiro",
                        column: x => x.PioneiroId,
                        principalSchema: "secretary",
                        principalTable: "Pioneiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "servico_campo$FK_ServicoCampo_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicoCampod",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    Estudos = table.Column<double>(nullable: false),
                    FolhetosBrochuras = table.Column<double>(nullable: false),
                    Horas = table.Column<double>(nullable: false),
                    HorasBetel = table.Column<double>(nullable: false),
                    CreditoHoras = table.Column<double>(nullable: false),
                    Livros = table.Column<double>(nullable: false),
                    Minutos = table.Column<double>(nullable: false),
                    Revisitas = table.Column<double>(nullable: false),
                    Revistas = table.Column<double>(nullable: false),
                    Publicacoes = table.Column<double>(nullable: false),
                    videos_mostrados = table.Column<double>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoCampod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoCampod_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "servico_campod$FK_ServicoCampod_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicoCampos",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    Estudos = table.Column<double>(nullable: false),
                    FolhetosBrochuras = table.Column<double>(nullable: false),
                    Horas = table.Column<double>(nullable: false),
                    HorasBetel = table.Column<double>(nullable: false),
                    CreditoHoras = table.Column<double>(nullable: false),
                    Livros = table.Column<double>(nullable: false),
                    Minutos = table.Column<double>(nullable: false),
                    Revisitas = table.Column<double>(nullable: false),
                    Revistas = table.Column<double>(nullable: false),
                    Publicacoes = table.Column<double>(nullable: false),
                    VideosMostrados = table.Column<double>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoCampos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoCampos_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "servico_campos$FK_ServicoCampos_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicoCampot",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    Estudos = table.Column<double>(nullable: false),
                    FolhetosBrochuras = table.Column<double>(nullable: false),
                    Horas = table.Column<double>(nullable: false),
                    HorasBetel = table.Column<double>(nullable: false),
                    CreditoHoras = table.Column<double>(nullable: false),
                    Livros = table.Column<double>(nullable: false),
                    Minutos = table.Column<double>(nullable: false),
                    Revisitas = table.Column<double>(nullable: false),
                    Revistas = table.Column<double>(nullable: false),
                    Publicacoes = table.Column<double>(nullable: false),
                    VideosMostrados = table.Column<double>(nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoCampot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoCampot_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "servico_campot$FK_ServicoCampot_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    AuditoriaUsuario = table.Column<long>(nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    Observacao = table.Column<string>(maxLength: 255, nullable: false),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false),
                    OrigemId = table.Column<long>(nullable: false),
                    DestinoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "transferencia$FK_TipoLogradouro_Destino",
                        column: x => x.DestinoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "transferencia$FK_TipoLogradouro_Origem",
                        column: x => x.OrigemId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "transferencia$FK_TipoLogradouro_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 255, nullable: false, defaultValueSql: "0"),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CongregacaoId = table.Column<long>(nullable: false),
                    PublicadorId = table.Column<long>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_Congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalSchema: "secretary",
                        principalTable: "Congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "usuario$IX_Usuario_Publicador",
                        column: x => x.PublicadorId,
                        principalSchema: "secretary",
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FK_AssistenciaReuniao_Congregacao",
                schema: "secretary",
                table: "AssistenciaReuniao",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_AssistenciaReuniao_Reuniao",
                schema: "secretary",
                table: "AssistenciaReuniao",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Congregacao_Estado",
                schema: "secretary",
                table: "Congregacao",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "FK_Congregacao_TipoLogradouro",
                schema: "secretary",
                table: "Congregacao",
                column: "TipoLogradouroId");

            migrationBuilder.CreateIndex(
                name: "FK_Dianteira_Congregacao",
                schema: "secretary",
                table: "Dianteira",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Estado_Country",
                schema: "secretary",
                table: "Estado",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "FK_Familia_ChefeFamilia",
                schema: "secretary",
                table: "Familia",
                column: "ChefeFamiliaId");

            migrationBuilder.CreateIndex(
                name: "FK_Familia_Congregacao",
                schema: "secretary",
                table: "Familia",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Membro",
                schema: "secretary",
                table: "Familia",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "FK_Familiares_Congregacao",
                schema: "secretary",
                table: "Familiares",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Familiares_Membro",
                schema: "secretary",
                table: "Familiares",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "FK_Familiares_Publicador",
                schema: "secretary",
                table: "Familiares",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_Grupo_Ajudante",
                schema: "secretary",
                table: "Grupo",
                column: "AjudanteId");

            migrationBuilder.CreateIndex(
                name: "FK_Grupo_Congregacao",
                schema: "secretary",
                table: "Grupo",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Grupo_Superintendente",
                schema: "secretary",
                table: "Grupo",
                column: "SuperintendenteId");

            migrationBuilder.CreateIndex(
                name: "FK_PeticaoPioneiroAuxiliar_Congregacao",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_PeticaoPioneiroAuxiliar_Pioneiro",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar",
                column: "PioneiroId");

            migrationBuilder.CreateIndex(
                name: "FK_PeticaoPioneiroAuxiliar_Publicador",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_Pioneiro_Congregacao",
                schema: "secretary",
                table: "Pioneiro",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_PrivilegioCongregacional_Congregacao",
                schema: "secretary",
                table: "PrivilegioCongregacional",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Publicador_Congregacao",
                schema: "secretary",
                table: "Publicador",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Publicador_Dianteira",
                schema: "secretary",
                table: "Publicador",
                column: "DianteiraId");

            migrationBuilder.CreateIndex(
                name: "FK_Publicador_Estado",
                schema: "secretary",
                table: "Publicador",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "FK__PublicadorGrupo",
                schema: "secretary",
                table: "Publicador",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "FK_Publicador_Pioneiro",
                schema: "secretary",
                table: "Publicador",
                column: "PioneiroId");

            migrationBuilder.CreateIndex(
                name: "FK_Publicador_Situacao",
                schema: "secretary",
                table: "Publicador",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Publicador_TipoLogradouro",
                schema: "secretary",
                table: "Publicador",
                column: "TipoLogradouroId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicadorHistorico_CongregacaoId",
                schema: "secretary",
                table: "PublicadorHistorico",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_PublicadorHistorico_Publicador",
                schema: "secretary",
                table: "PublicadorHistorico",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicadorPrivilegios_CongregacaoId",
                schema: "secretary",
                table: "PublicadorPrivilegios",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_PublicadorPrivilegios_Publicador",
                schema: "secretary",
                table: "PublicadorPrivilegios",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_PublicadorPrivilegios_PrivilegioCongregacional",
                schema: "secretary",
                table: "PublicadorPrivilegios",
                columns: new[] { "PrivilegioCongregacionalId", "PublicadorId" });

            migrationBuilder.CreateIndex(
                name: "IX_PublicadorUsuario_CongregacaoId",
                schema: "secretary",
                table: "PublicadorUsuario",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_PublicadorUsuario_Publicador",
                schema: "secretary",
                table: "PublicadorUsuario",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "usuario_id",
                schema: "secretary",
                table: "PublicadorUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_CongregacaoId",
                schema: "secretary",
                table: "Recibo",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Recibo_Reuniao",
                schema: "secretary",
                table: "Recibo",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "FK_Reuniao_Congregacao",
                schema: "secretary",
                table: "Reuniao",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampo_Congregacao",
                schema: "secretary",
                table: "ServicoCampo",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampo_Pioneiro",
                schema: "secretary",
                table: "ServicoCampo",
                column: "PioneiroId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampo_Publicador",
                schema: "secretary",
                table: "ServicoCampo",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampo_Congregacao_Publicador",
                schema: "secretary",
                table: "ServicoCampo",
                columns: new[] { "CongregacaoId", "PublicadorId" });

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampo_Congregacao_Publicador_DataReferencia",
                schema: "secretary",
                table: "ServicoCampo",
                columns: new[] { "CongregacaoId", "PublicadorId", "DataReferencia" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampod_Publicador",
                schema: "secretary",
                table: "ServicoCampod",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampod_Congregacao_Publicador",
                schema: "secretary",
                table: "ServicoCampod",
                columns: new[] { "CongregacaoId", "PublicadorId" });

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampos_Publicador",
                schema: "secretary",
                table: "ServicoCampos",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampos_Congregacao_Publicador",
                schema: "secretary",
                table: "ServicoCampos",
                columns: new[] { "CongregacaoId", "PublicadorId" });

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampot_Publicador",
                schema: "secretary",
                table: "ServicoCampot",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "FK_ServicoCampot_Congregacao_Publicador",
                schema: "secretary",
                table: "ServicoCampot",
                columns: new[] { "CongregacaoId", "PublicadorId" });

            migrationBuilder.CreateIndex(
                name: "FK_Situacao_Congregacao",
                schema: "secretary",
                table: "Situacao",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Situacao_Descricao",
                schema: "secretary",
                table: "Situacao",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Descricao",
                schema: "secretary",
                table: "TipoLogradouro",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_CongregacaoId",
                schema: "secretary",
                table: "Transferencia",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "FK_TipoLogradouro_Destino",
                schema: "secretary",
                table: "Transferencia",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "FK_TipoLogradouro_Origem",
                schema: "secretary",
                table: "Transferencia",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "FK_TipoLogradouro_Publicador",
                schema: "secretary",
                table: "Transferencia",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                schema: "secretary",
                table: "usuario",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Publicador",
                schema: "secretary",
                table: "usuario",
                column: "PublicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Username",
                schema: "secretary",
                table: "usuario",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Congregacao_Publicador",
                schema: "secretary",
                table: "usuario",
                columns: new[] { "CongregacaoId", "PublicadorId" });

            migrationBuilder.AddForeignKey(
                name: "familia$FK_Familia_ChefeFamilia",
                schema: "secretary",
                table: "Familia",
                column: "ChefeFamiliaId",
                principalSchema: "secretary",
                principalTable: "Publicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "familia$FK_Familia_Membro",
                schema: "secretary",
                table: "Familia",
                column: "MembroId",
                principalSchema: "secretary",
                principalTable: "Publicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "familiares$FK_Familiares_Membro",
                schema: "secretary",
                table: "Familiares",
                column: "MembroId",
                principalSchema: "secretary",
                principalTable: "Publicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "familiares$FK_Familiares_Publicador",
                schema: "secretary",
                table: "Familiares",
                column: "PublicadorId",
                principalSchema: "secretary",
                principalTable: "Publicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "grupo$FK_Grupo_Ajudante",
                schema: "secretary",
                table: "Grupo",
                column: "AjudanteId",
                principalSchema: "secretary",
                principalTable: "Publicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "grupo$FK_Grupo_Superintendente",
                schema: "secretary",
                table: "Grupo",
                column: "SuperintendenteId",
                principalSchema: "secretary",
                principalTable: "Publicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Dianteira$FK_Dianteira_Congregacao",
                schema: "secretary",
                table: "Dianteira");

            migrationBuilder.DropForeignKey(
                name: "grupo$FK_Grupo_Congregacao",
                schema: "secretary",
                table: "Grupo");

            migrationBuilder.DropForeignKey(
                name: "grupo$FK_Pioneiro_Congregacao",
                schema: "secretary",
                table: "Pioneiro");

            migrationBuilder.DropForeignKey(
                name: "publicador$FK_Publicador_Congregacao",
                schema: "secretary",
                table: "Publicador");

            migrationBuilder.DropForeignKey(
                name: "FK_Situacao_Congregacao_CongregacaoId",
                schema: "secretary",
                table: "Situacao");

            migrationBuilder.DropForeignKey(
                name: "publicador$FK_Publicador_Estado",
                schema: "secretary",
                table: "Publicador");

            migrationBuilder.DropForeignKey(
                name: "publicador$FK_Publicador_TipoLogradouro",
                schema: "secretary",
                table: "Publicador");

            migrationBuilder.DropForeignKey(
                name: "grupo$FK_Grupo_Ajudante",
                schema: "secretary",
                table: "Grupo");

            migrationBuilder.DropForeignKey(
                name: "grupo$FK_Grupo_Superintendente",
                schema: "secretary",
                table: "Grupo");

            migrationBuilder.DropTable(
                name: "AssistenciaReuniao",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Familia",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Familiares",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "PeticaoPioneiroAuxiliar",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "PublicadorHistorico",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "PublicadorPrivilegios",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "PublicadorUsuario",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Recibo",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "ServicoCampo",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "ServicoCampod",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "ServicoCampos",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "ServicoCampot",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Transferencia",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "PrivilegioCongregacional",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Reuniao",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Congregacao",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Estado",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "TipoLogradouro",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Publicador",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Dianteira",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Grupo",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Pioneiro",
                schema: "secretary");

            migrationBuilder.DropTable(
                name: "Situacao",
                schema: "secretary");
        }
    }
}
