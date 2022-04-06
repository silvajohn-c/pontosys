﻿using pontosys.Domain.Entities;

namespace pontosys.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        Task<int> SaveChanges();
        Funcionario GetFuncionarioByCpf(long cpf);
        Cargo GetCargoByName(string cargo);
        Expediente GetExpedienteByValue(int cargaHoraria);
        ModalidadeContrato GetModalidadeContratoByName(string modalidadeContrato);
        Contrato GetContratoByForeignKeys(string funcionarioId, string cargoId, string expedienteId, string modalidadeContratoId, DateTime inicioContrato);
    }
}