using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pontosys.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadesContratos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadesContratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadesHorasExtras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadesHorasExtras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosHorasExtras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosHorasExtras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOcorrencias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOcorrencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposOcorrencias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOcorrencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosPontos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FuncionarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosPontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosPontos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModalidadeContratoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpedienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CargoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_ModalidadesContratos_ModalidadeContratoId",
                        column: x => x.ModalidadeContratoId,
                        principalTable: "ModalidadesContratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorasExtras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    FuncionarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModalidadeHoraExtraId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PeriodoHoraExtraId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorasExtras_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorasExtras_ModalidadesHorasExtras_ModalidadeHoraExtraId",
                        column: x => x.ModalidadeHoraExtraId,
                        principalTable: "ModalidadesHorasExtras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorasExtras_PeriodosHorasExtras_PeriodoHoraExtraId",
                        column: x => x.PeriodoHoraExtraId,
                        principalTable: "PeriodosHorasExtras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusOcorrenciaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoOcorrenciaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FuncionarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocorrencias_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencias_StatusOcorrencias_StatusOcorrenciaId",
                        column: x => x.StatusOcorrenciaId,
                        principalTable: "StatusOcorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencias_TiposOcorrencias_TipoOcorrenciaId",
                        column: x => x.TipoOcorrenciaId,
                        principalTable: "TiposOcorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_CargoId",
                table: "Contratos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ExpedienteId",
                table: "Contratos",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ModalidadeContratoId",
                table: "Contratos",
                column: "ModalidadeContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasExtras_FuncionarioId",
                table: "HorasExtras",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasExtras_ModalidadeHoraExtraId",
                table: "HorasExtras",
                column: "ModalidadeHoraExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasExtras_PeriodoHoraExtraId",
                table: "HorasExtras",
                column: "PeriodoHoraExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_FuncionarioId",
                table: "Ocorrencias",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_StatusOcorrenciaId",
                table: "Ocorrencias",
                column: "StatusOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_TipoOcorrenciaId",
                table: "Ocorrencias",
                column: "TipoOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPontos_FuncionarioId",
                table: "RegistrosPontos",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "HorasExtras");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "RegistrosPontos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "ModalidadesContratos");

            migrationBuilder.DropTable(
                name: "ModalidadesHorasExtras");

            migrationBuilder.DropTable(
                name: "PeriodosHorasExtras");

            migrationBuilder.DropTable(
                name: "StatusOcorrencias");

            migrationBuilder.DropTable(
                name: "TiposOcorrencias");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
