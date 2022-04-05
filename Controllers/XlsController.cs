using Microsoft.AspNetCore.Mvc;
using pontosys.Domain.Entities;
using pontosys.Data.Context;
using Microsoft.EntityFrameworkCore;
using pontosys.Domain.Models;
using Ganss.Excel;

namespace pontosys.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XlsController : ControllerBase
    {
        private readonly PontosysContext context;
        public XlsController(PontosysContext context)
        {
            this.context = context;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            var results = new ExcelMapper(file.OpenReadStream()).Fetch<XlsModel>();

            foreach (var registro in results)
            {
                //Set Funcionario
                var funcionario = new Funcionario();

                if (FuncionarioExists(registro.Cpf))
                {
                    funcionario.Id = GetFuncionario(registro.Cpf);
                }
                else
                {
                    funcionario.Nome = registro.Nome;
                    funcionario.Sobrenome = registro.Sobrenome;
                    funcionario.Cpf = registro.Cpf;
                    this.context.Funcionarios.Add(funcionario);

                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Falha no banco de dados: {ex.Message}");
                    }
                }

                //Set Cargo
                var cargo = new Cargo();

                if (CargoExists(registro.Cargo))
                {
                    cargo.Id = GetCargo(registro.Cargo);
                }
                else
                {
                    cargo.Nome = registro.Cargo;
                    this.context.Cargos.Add(cargo);

                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Falha no banco de dados: {ex.Message}");
                    }
                }

                //Set Expediente
                var expediente = new Expediente();

                if (ExpedienteExists(registro.CargaHoraria))
                {
                    expediente.Id = GetExpediente(registro.CargaHoraria);
                }
                else
                {
                    expediente.CargaHoraria = registro.CargaHoraria;
                    this.context.Expedientes.Add(expediente);

                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Falha no banco de dados: {ex.Message}");
                    }
                }

                //Set ModalidadeContrato
                var modalidadeContrato = new ModalidadeContrato();

                if (ModalidadeContratoExists(registro.ModalidadeContrato))
                {
                    modalidadeContrato.Id = GetModalidadeContrato(registro.ModalidadeContrato);
                }
                else
                {
                    modalidadeContrato.Nome = registro.ModalidadeContrato;
                    this.context.ModalidadesContratos.Add(modalidadeContrato);

                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Falha no banco de dados: {ex.Message}");
                    }
                }

                //Set Contrato
                var contrato = new Contrato();

                if (ContratoExists(funcionario.Id))
                {
                    contrato.Id = GetContrato(funcionario.Id);
                }
                else
                {
                    contrato.FuncionarioId = funcionario.Id;
                    contrato.CargoId = cargo.Id;
                    contrato.ExpedienteId = expediente.Id;
                    contrato.ModalidadeContratoId = modalidadeContrato.Id;
                    contrato.DataInicio = registro.InicioContrato;
                    this.context.Contratos.Add(contrato);

                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Falha no banco de dados: {ex.Message}");
                    }
                }
            }

            return Ok();
        }
        private bool FuncionarioExists(long Cpf)
        {
            return this.context.Funcionarios.Any(e => e.Cpf == Cpf);
        }
        private string GetFuncionario(long FCpf)
        {
            return this.context.Funcionarios
                    .Where(x => x.Cpf.Equals(FCpf))
                    .Select(x => x.Id)
                    .Single();
        }
        private bool CargoExists(string Nome)
        {
            return this.context.Cargos.Any(e => e.Nome == Nome);
        }
        private string GetCargo(string Nome)
        {
            return this.context.Cargos
                    .Where(x => x.Nome == Nome)
                    .Select(x => x.Id)
                    .Single();
        }
        private bool ExpedienteExists(int CargaHoraria)
        {
            return this.context.Expedientes.Any(e => e.CargaHoraria == CargaHoraria);
        }
        private string GetExpediente(int CargaHoraria)
        {
            return this.context.Expedientes
                    .Where(x => x.CargaHoraria == CargaHoraria)
                    .Select(x => x.Id)
                    .Single();
        }
        private bool ModalidadeContratoExists(string ModalidadeContrato)
        {
            return this.context.ModalidadesContratos.Any(e => e.Nome == ModalidadeContrato);
        }
        private string GetModalidadeContrato(string Nome)
        {
            return this.context.ModalidadesContratos
                    .Where(x => x.Nome == Nome)
                    .Select(x => x.Id)
                    .Single();
        }
        private bool ContratoExists(string funcionarioId)
        {
            return this.context.Contratos.Any(e => e.FuncionarioId == funcionarioId);
        }
        private string GetContrato(string funcionarioId)
        {
            return this.context.Contratos
                    .Where(x => x.FuncionarioId == funcionarioId)
                    .Select(x => x.Id)
                    .Single();
        }
    }
}