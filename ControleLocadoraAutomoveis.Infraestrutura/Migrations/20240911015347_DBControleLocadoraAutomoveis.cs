using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleLocadoraAutomoveis.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class DBControleLocadoraAutomoveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    TipoCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroEndereco = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCliente_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBConfiguracaoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorGasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAlcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConfiguracaoCombustivel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBConfiguracaoCombustivel_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAdmissão = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBFuncionario_AspNetUsers_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoAutomoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBGrupoAutomoveis_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCobranca = table.Column<int>(type: "int", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTaxa_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteCondutor = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(20)", nullable: false),
                    ValidadeCNH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false, defaultValue: new byte[0]),
                    IdGrupoAutomoveis = table.Column<int>(type: "int", nullable: false),
                    TipoCcombustivel = table.Column<int>(type: "int", nullable: false),
                    Alugado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_TBGrupoAutomoveis_IdGrupoAutomoveis",
                        column: x => x.IdGrupoAutomoveis,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoDeCobranca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGrupoAutomoveis = table.Column<int>(type: "int", nullable: false),
                    PrecoDiarioPlanoDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoQuilometroPlanoDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuilometrosDisponiveisPlanoControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiarioPlanoControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoQuilometroExtrapoldoPlanoControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiarioPlanoLivre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoDeCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoDeCobranca_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBPlanoDeCobranca_TBGrupoAutomoveis_IdGrupoAutomoveis",
                        column: x => x.IdGrupoAutomoveis,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCondutor = table.Column<int>(type: "int", nullable: false),
                    IdAutomovel = table.Column<int>(type: "int", nullable: false),
                    IdConfiguracaoCombustivel = table.Column<int>(type: "int", nullable: false),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
                    MarcadorCombustivel = table.Column<int>(type: "int", nullable: false),
                    QuilometragemPercorrida = table.Column<int>(type: "int", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_AspNetUsers_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBAutomovel_IdAutomovel",
                        column: x => x.IdAutomovel,
                        principalTable: "TBAutomovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCondutor_IdCondutor",
                        column: x => x.IdCondutor,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBConfiguracaoCombustivel_IdConfiguracaoCombustivel",
                        column: x => x.IdConfiguracaoCombustivel,
                        principalTable: "TBConfiguracaoCombustivel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<int>(type: "int", nullable: false),
                    TaxasSelecionadasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacaoTaxa", x => new { x.LocacoesId, x.TaxasSelecionadasId });
                    table.ForeignKey(
                        name: "FK_TBLocacaoTaxa_TBLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                        column: x => x.TaxasSelecionadasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_Id_Empresa",
                table: "TBAutomovel",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_IdGrupoAutomoveis",
                table: "TBAutomovel",
                column: "IdGrupoAutomoveis");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_Id_Empresa",
                table: "TBCliente",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_Id_Empresa",
                table: "TBCondutor",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_IdCliente",
                table: "TBCondutor",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBConfiguracaoCombustivel_Id_Empresa",
                table: "TBConfiguracaoCombustivel",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBFuncionario_IdEmpresa",
                table: "TBFuncionario",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBGrupoAutomoveis_Id_Empresa",
                table: "TBGrupoAutomoveis",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_Id_Empresa",
                table: "TBLocacao",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_IdAutomovel",
                table: "TBLocacao",
                column: "IdAutomovel");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_IdCondutor",
                table: "TBLocacao",
                column: "IdCondutor");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_IdConfiguracaoCombustivel",
                table: "TBLocacao",
                column: "IdConfiguracaoCombustivel");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoTaxa_TaxasSelecionadasId",
                table: "TBLocacaoTaxa",
                column: "TaxasSelecionadasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_Id_Empresa",
                table: "TBPlanoDeCobranca",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_IdGrupoAutomoveis",
                table: "TBPlanoDeCobranca",
                column: "IdGrupoAutomoveis");

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_Id_Empresa",
                table: "TBTaxa",
                column: "Id_Empresa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBLocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropTable(
                name: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBAutomovel");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBConfiguracaoCombustivel");

            migrationBuilder.DropTable(
                name: "TBGrupoAutomoveis");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
