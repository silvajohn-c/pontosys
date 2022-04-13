using Ganss.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pontosys.Data.Repository;
using pontosys.Domain.Entities;
using pontosys.Domain.Models;
using pontosys.Validators;

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
            var planilha = new ExcelMapper(file.OpenReadStream()).Fetch<XlsModel>();

            foreach (var linha in planilha)
            {
                XlsValidator xlsValidator = new();
                var validatorResult = xlsValidator.Validate(linha);
                if (!validatorResult.IsValid) return StatusCode(StatusCodes.Status400BadRequest, this.service.GetValidationErrors(validatorResult) + $"Funcionario de CPF: {linha.Cpf}");

                Funcionario funcionario = this.service.GetFuncionario(linha.Cpf);
                
                if (funcionario == null)
                {                            
                    funcionario = new Funcionario();
                    funcionario.Cpf = linha.Cpf;
                    funcionario.Nome = linha.Nome;
                    funcionario.Sobrenome = linha.Sobrenome;
                    this.service.Add(funcionario);
                }

                Cargo cargo = this.service.GetCargo(linha.Cargo);

                if (cargo == null)
                {
                    cargo = new Cargo();
                    cargo.Nome = linha.Cargo;
                    this.service.Add(cargo);
                }

                Expediente expediente = this.service.GetExpediente(linha.CargaHoraria);
                
                if (expediente == null && linha.CargaHoraria != default(int))
                {
                    expediente = new Expediente();
                    expediente.CargaHoraria = linha.CargaHoraria;
                    this.service.Add(expediente);
                }

                ModalidadeContrato modalidadeContrato = this.service.GetModalidadeContrato(linha.ModalidadeContrato);
                
                if (modalidadeContrato == null)
                {
                    modalidadeContrato = new ModalidadeContrato();
                    modalidadeContrato.Nome = linha.ModalidadeContrato;
                    this.service.Add(modalidadeContrato);
                }

                Contrato contrato = this.service.GetContrato(funcionario, cargo, expediente, modalidadeContrato, linha.InicioContrato);

                if (contrato == null)
                {
                    contrato = new Contrato();
                    contrato.FuncionarioId = funcionario.Id;
                    contrato.CargoId = cargo.Id;
                    contrato.ExpedienteId = expediente.Id;
                    contrato.ModalidadeContratoId = modalidadeContrato.Id;
                    contrato.DataInicio = linha.InicioContrato;
                    contrato.DataFim = linha.FimContrato;
                    this.service.Add(contrato);
                }
            
                if (linha.RegistroPonto != default(DateTime))
                {
                    this.service.AddRegistroPonto(linha.RegistroPonto, funcionario.Id);
                }
            }

            try
            {
                await this.service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Falha ao inserir os dados no banco: {ex.Message}");
            }

            return Ok("Dados inseridos com sucesso!");
        }
    }
}