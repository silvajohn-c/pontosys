using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pontosys.Migrations
{
    public partial class DateOcorrencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Cargos_CargoId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Expedientes_ExpedienteId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Funcionarios_FuncionarioId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_ModalidadesContratos_ModalidadeContratoId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_Funcionarios_FuncionarioId",
                table: "HorasExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_ModalidadesHorasExtras_ModalidadeHoraExtraId",
                table: "HorasExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_PeriodosHorasExtras_PeriodoHoraExtraId",
                table: "HorasExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_Funcionarios_FuncionarioId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_StatusOcorrencias_StatusOcorrenciaId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_TiposOcorrencias_TipoOcorrenciaId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPontos_Funcionarios_FuncionarioId",
                table: "RegistrosPontos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TiposOcorrencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "StatusOcorrencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "StatusOcorrencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "RegistrosPontos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "PeriodosHorasExtras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TipoOcorrenciaId",
                table: "Ocorrencias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StatusOcorrenciaId",
                table: "Ocorrencias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Ocorrencias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Ocorrencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Ocorrencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ModalidadesHorasExtras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ModalidadesContratos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PeriodoHoraExtraId",
                table: "HorasExtras",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModalidadeHoraExtraId",
                table: "HorasExtras",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "HorasExtras",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ModalidadeContratoId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ExpedienteId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CargoId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cargos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Cargos_CargoId",
                table: "Contratos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Expedientes_ExpedienteId",
                table: "Contratos",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Funcionarios_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_ModalidadesContratos_ModalidadeContratoId",
                table: "Contratos",
                column: "ModalidadeContratoId",
                principalTable: "ModalidadesContratos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_Funcionarios_FuncionarioId",
                table: "HorasExtras",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_ModalidadesHorasExtras_ModalidadeHoraExtraId",
                table: "HorasExtras",
                column: "ModalidadeHoraExtraId",
                principalTable: "ModalidadesHorasExtras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_PeriodosHorasExtras_PeriodoHoraExtraId",
                table: "HorasExtras",
                column: "PeriodoHoraExtraId",
                principalTable: "PeriodosHorasExtras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_Funcionarios_FuncionarioId",
                table: "Ocorrencias",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_StatusOcorrencias_StatusOcorrenciaId",
                table: "Ocorrencias",
                column: "StatusOcorrenciaId",
                principalTable: "StatusOcorrencias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_TiposOcorrencias_TipoOcorrenciaId",
                table: "Ocorrencias",
                column: "TipoOcorrenciaId",
                principalTable: "TiposOcorrencias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPontos_Funcionarios_FuncionarioId",
                table: "RegistrosPontos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Cargos_CargoId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Expedientes_ExpedienteId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Funcionarios_FuncionarioId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_ModalidadesContratos_ModalidadeContratoId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_Funcionarios_FuncionarioId",
                table: "HorasExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_ModalidadesHorasExtras_ModalidadeHoraExtraId",
                table: "HorasExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_PeriodosHorasExtras_PeriodoHoraExtraId",
                table: "HorasExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_Funcionarios_FuncionarioId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_StatusOcorrencias_StatusOcorrenciaId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_TiposOcorrencias_TipoOcorrenciaId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPontos_Funcionarios_FuncionarioId",
                table: "RegistrosPontos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Ocorrencias");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TiposOcorrencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "StatusOcorrencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "StatusOcorrencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "RegistrosPontos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "PeriodosHorasExtras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoOcorrenciaId",
                table: "Ocorrencias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusOcorrenciaId",
                table: "Ocorrencias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Ocorrencias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Ocorrencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ModalidadesHorasExtras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ModalidadesContratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PeriodoHoraExtraId",
                table: "HorasExtras",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModalidadeHoraExtraId",
                table: "HorasExtras",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "HorasExtras",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModalidadeContratoId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpedienteId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CargoId",
                table: "Contratos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cargos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Cargos_CargoId",
                table: "Contratos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Expedientes_ExpedienteId",
                table: "Contratos",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Funcionarios_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_ModalidadesContratos_ModalidadeContratoId",
                table: "Contratos",
                column: "ModalidadeContratoId",
                principalTable: "ModalidadesContratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_Funcionarios_FuncionarioId",
                table: "HorasExtras",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_ModalidadesHorasExtras_ModalidadeHoraExtraId",
                table: "HorasExtras",
                column: "ModalidadeHoraExtraId",
                principalTable: "ModalidadesHorasExtras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_PeriodosHorasExtras_PeriodoHoraExtraId",
                table: "HorasExtras",
                column: "PeriodoHoraExtraId",
                principalTable: "PeriodosHorasExtras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_Funcionarios_FuncionarioId",
                table: "Ocorrencias",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_StatusOcorrencias_StatusOcorrenciaId",
                table: "Ocorrencias",
                column: "StatusOcorrenciaId",
                principalTable: "StatusOcorrencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_TiposOcorrencias_TipoOcorrenciaId",
                table: "Ocorrencias",
                column: "TipoOcorrenciaId",
                principalTable: "TiposOcorrencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPontos_Funcionarios_FuncionarioId",
                table: "RegistrosPontos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
