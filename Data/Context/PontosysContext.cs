using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using pontosys.Domain.Entities;

namespace pontosys.Data.Context
{
    public partial class PontosysContext : DbContext
    {
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<Expediente> Expedientes { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<HoraExtra> HorasExtras { get; set; }
        public virtual DbSet<ModalidadeContrato> ModalidadesContratos { get; set; }
        public virtual DbSet<ModalidadeHoraExtra> ModalidadesHorasExtras { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencias { get; set; }
        public virtual DbSet<PeriodoHoraExtra> PeriodosHorasExtras { get; set; }
        public virtual DbSet<RegistroPonto> RegistrosPontos { get; set; }
        public virtual DbSet<StatusOcorrencia> StatusOcorrencias { get; set; }
        public virtual DbSet<TipoOcorrencia> TiposOcorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasIndex(e => e.CargoId, "IX_Contratos_CargoId");

                entity.HasIndex(e => e.ExpedienteId, "IX_Contratos_ExpedienteId");

                entity.HasIndex(e => e.FuncionarioId, "IX_Contratos_FuncionarioId");

                entity.HasIndex(e => e.ModalidadeContratoId, "IX_Contratos_ModalidadeContratoId");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.CargoId);

                entity.HasOne(d => d.Expediente)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ExpedienteId);

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.FuncionarioId);

                entity.HasOne(d => d.ModalidadeContrato)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ModalidadeContratoId);
            });

            modelBuilder.Entity<HoraExtra>(entity =>
            {
                entity.HasIndex(e => e.FuncionarioId, "IX_HorasExtras_FuncionarioId");

                entity.HasIndex(e => e.ModalidadeHoraExtraId, "IX_HorasExtras_ModalidadeHoraExtraId");

                entity.HasIndex(e => e.PeriodoHoraExtraId, "IX_HorasExtras_PeriodoHoraExtraId");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.HorasExtras)
                    .HasForeignKey(d => d.FuncionarioId);

                entity.HasOne(d => d.ModalidadeHoraExtra)
                    .WithMany(p => p.HorasExtras)
                    .HasForeignKey(d => d.ModalidadeHoraExtraId);

                entity.HasOne(d => d.PeriodoHoraExtra)
                    .WithMany(p => p.HorasExtras)
                    .HasForeignKey(d => d.PeriodoHoraExtraId);
            });

            modelBuilder.Entity<Ocorrencia>(entity =>
            {
                entity.HasIndex(e => e.FuncionarioId, "IX_Ocorrencias_FuncionarioId");

                entity.HasIndex(e => e.StatusOcorrenciaId, "IX_Ocorrencias_StatusOcorrenciaId");

                entity.HasIndex(e => e.TipoOcorrenciaId, "IX_Ocorrencias_TipoOcorrenciaId");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.FuncionarioId);

                entity.HasOne(d => d.StatusOcorrencia)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.StatusOcorrenciaId);

                entity.HasOne(d => d.TipoOcorrencia)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.TipoOcorrenciaId);
            });

            modelBuilder.Entity<RegistroPonto>(entity =>
            {
                entity.HasIndex(e => e.FuncionarioId, "IX_RegistrosPontos_FuncionarioId");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.RegistrosPontos)
                    .HasForeignKey(d => d.FuncionarioId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}