using Ganss.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pontosys.Data.Repository;
using pontosys.Domain.Entities;
using pontosys.Domain.Models;
namespace pontosys.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XlsController : ControllerBase
    {

        private readonly IRepository service;

        public XlsController(IRepository service)
        {
            this.service = service;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var results =
                new ExcelMapper(file.OpenReadStream()).Fetch<XlsModel>();

            foreach (var registro in results)
            {
                //Set Funcionario                
                Funcionario funcionario = this.service.GetFuncionarioByCpf(registro.Cpf);

                if (funcionario == null)
                {
                    funcionario = new Funcionario();
                    funcionario.Nome = registro.Nome;
                    funcionario.Sobrenome = registro.Sobrenome;
                    funcionario.Cpf = registro.Cpf;
                    this.service.Add(funcionario);

                    try
                    {
                        await this.service.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this
                            .StatusCode(StatusCodes
                            .Status500InternalServerError,
                            $"Falha ao inserir funcionário: {ex.Message}");
                    }
                }

                //Set Cargo
                Cargo cargo = this.service.GetCargoByName(registro.Cargo);

                if (cargo == null)
                {
                    cargo = new Cargo();
                    cargo.Nome = registro.Cargo;
                    this.service.Add(cargo);

                    try
                    {
                        await this.service.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this
                            .StatusCode(StatusCodes
                            .Status500InternalServerError,
                            $"Falha ao inserir cargo: {ex.Message}");
                    }
                }

                //Set Expediente
                Expediente expediente = this.service.GetExpedienteByValue(registro.CargaHoraria);

                if (expediente == null)
                {
                    expediente = new Expediente();
                    expediente.CargaHoraria = registro.CargaHoraria;
                    this.service.Add(expediente);

                    try
                    {
                        await this.service.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this
                            .StatusCode(StatusCodes
                                .Status500InternalServerError,
                            $"Falha ao inserir expediente: {ex.Message}");
                    }
                }

                //Set ModalidadeContrato
                ModalidadeContrato modalidadeContrato = this.service.GetModalidadeContratoByName(registro.ModalidadeContrato);

                if (modalidadeContrato == null)
                {
                    modalidadeContrato = new ModalidadeContrato();
                    modalidadeContrato.Nome = registro.ModalidadeContrato;
                    this.service.Add(modalidadeContrato);

                    try
                    {
                        await this.service.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this
                            .StatusCode(StatusCodes
                            .Status500InternalServerError,
                            $"Falha ao inserir modalidade de contrato: {ex.Message}");
                    }
                }

                //Set Contrato
                Contrato contrato = this.service.GetContratoByForeignKeys(funcionario.Id, cargo.Id, expediente.Id, modalidadeContrato.Id, registro.InicioContrato);

                if (contrato == null)
                {
                    contrato = new Contrato();
                    contrato.FuncionarioId = funcionario.Id;
                    contrato.CargoId = cargo.Id;
                    contrato.ExpedienteId = expediente.Id;
                    contrato.ModalidadeContratoId = modalidadeContrato.Id;
                    contrato.DataInicio = registro.InicioContrato;
                    contrato.DataFim = registro.FimContrato;
                    this.service.Add(contrato);

                    try
                    {
                        await this.service.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this
                            .StatusCode(StatusCodes
                                .Status500InternalServerError,
                            $"Falha ao inserir contrato: {ex.Message}");
                    }
                }
            }

            return Ok();
        }
    }
}
