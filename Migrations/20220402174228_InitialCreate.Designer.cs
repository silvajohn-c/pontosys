// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pontosys.Data.Context;

#nullable disable

namespace pontosys.Migrations
{
    [DbContext(typeof(PontosysContext))]
    [Migration("20220402174228_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("pontosys.Domain.Entities.Cargo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Contrato", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CargoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpedienteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FuncionarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModalidadeContratoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CargoId" }, "IX_Contratos_CargoId");

                    b.HasIndex(new[] { "ExpedienteId" }, "IX_Contratos_ExpedienteId");

                    b.HasIndex(new[] { "FuncionarioId" }, "IX_Contratos_FuncionarioId");

                    b.HasIndex(new[] { "ModalidadeContratoId" }, "IX_Contratos_ModalidadeContratoId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Expediente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Expedientes");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Funcionario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long>("Cpf")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.HoraExtra", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FuncionarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModalidadeHoraExtraId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PeriodoHoraExtraId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FuncionarioId" }, "IX_HorasExtras_FuncionarioId");

                    b.HasIndex(new[] { "ModalidadeHoraExtraId" }, "IX_HorasExtras_ModalidadeHoraExtraId");

                    b.HasIndex(new[] { "PeriodoHoraExtraId" }, "IX_HorasExtras_PeriodoHoraExtraId");

                    b.ToTable("HorasExtras");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.ModalidadeContrato", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ModalidadesContratos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.ModalidadeHoraExtra", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ModalidadesHorasExtras");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Ocorrencia", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuncionarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StatusOcorrenciaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TipoOcorrenciaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FuncionarioId" }, "IX_Ocorrencias_FuncionarioId");

                    b.HasIndex(new[] { "StatusOcorrenciaId" }, "IX_Ocorrencias_StatusOcorrenciaId");

                    b.HasIndex(new[] { "TipoOcorrenciaId" }, "IX_Ocorrencias_TipoOcorrenciaId");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.PeriodoHoraExtra", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PeriodosHorasExtras");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.RegistroPonto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FuncionarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FuncionarioId" }, "IX_RegistrosPontos_FuncionarioId");

                    b.ToTable("RegistrosPontos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.StatusOcorrencia", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StatusOcorrencias");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.TipoOcorrencia", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TiposOcorrencias");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Contrato", b =>
                {
                    b.HasOne("pontosys.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Contratos")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.Expediente", "Expediente")
                        .WithMany("Contratos")
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Contratos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.ModalidadeContrato", "ModalidadeContrato")
                        .WithMany("Contratos")
                        .HasForeignKey("ModalidadeContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Expediente");

                    b.Navigation("Funcionario");

                    b.Navigation("ModalidadeContrato");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.HoraExtra", b =>
                {
                    b.HasOne("pontosys.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("HorasExtras")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.ModalidadeHoraExtra", "ModalidadeHoraExtra")
                        .WithMany("HorasExtras")
                        .HasForeignKey("ModalidadeHoraExtraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.PeriodoHoraExtra", "PeriodoHoraExtra")
                        .WithMany("HorasExtras")
                        .HasForeignKey("PeriodoHoraExtraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("ModalidadeHoraExtra");

                    b.Navigation("PeriodoHoraExtra");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Ocorrencia", b =>
                {
                    b.HasOne("pontosys.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.StatusOcorrencia", "StatusOcorrencia")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("StatusOcorrenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pontosys.Domain.Entities.TipoOcorrencia", "TipoOcorrencia")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("TipoOcorrenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("StatusOcorrencia");

                    b.Navigation("TipoOcorrencia");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.RegistroPonto", b =>
                {
                    b.HasOne("pontosys.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("RegistrosPontos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Cargo", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Expediente", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.Funcionario", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("HorasExtras");

                    b.Navigation("Ocorrencias");

                    b.Navigation("RegistrosPontos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.ModalidadeContrato", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.ModalidadeHoraExtra", b =>
                {
                    b.Navigation("HorasExtras");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.PeriodoHoraExtra", b =>
                {
                    b.Navigation("HorasExtras");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.StatusOcorrencia", b =>
                {
                    b.Navigation("Ocorrencias");
                });

            modelBuilder.Entity("pontosys.Domain.Entities.TipoOcorrencia", b =>
                {
                    b.Navigation("Ocorrencias");
                });
#pragma warning restore 612, 618
        }
    }
}
