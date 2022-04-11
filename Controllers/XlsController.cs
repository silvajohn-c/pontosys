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
                Funcionario funcionario = this.service.AddFuncionario(linha.Cpf, linha.Nome, linha.Sobrenome);
                
                if (funcionario == null)
                {                            
                    funcionario = new Funcionario();
                    funcionario.Cpf = linha.Cpf;
                    funcionario.Nome = linha.Nome;
                    funcionario.Sobrenome = linha.Sobrenome;

                    FuncionarioValidator funcionarioValidator = new();
                    var validatorResult = funcionarioValidator.Validate(funcionario);
                    if (!validatorResult.IsValid) return StatusCode(StatusCodes.Status400BadRequest, this.service.validationErrors(validatorResult) + $"Funcionario de CPF: {linha.Cpf}");
                    
                    this.service.Add(funcionario);
                }

                Cargo cargo = this.service.AddCargo(linha.Cargo);

                if (cargo == null && !String.IsNullOrEmpty(linha.Cargo))
                {
                    cargo = new Cargo();
                    cargo.Nome = linha.Cargo;

                    CargoValidator cargoValidator = new();
                    var validatorResult = cargoValidator.Validate(cargo);
                    if (!validatorResult.IsValid) return StatusCode(StatusCodes.Status400BadRequest, this.service.validationErrors(validatorResult) + $"Funcionario de CPF: {linha.Cpf}");

                    this.service.Add(cargo);
                }

                Expediente expediente = this.service.AddExpediente(linha.CargaHoraria);
                
                if (expediente == null && linha.CargaHoraria != default(int))
                {
                    expediente = new Expediente();
                    expediente.CargaHoraria = linha.CargaHoraria;

                    ExpedienteValidator expedienteValidator = new();
                    var validatorResult = expedienteValidator.Validate(expediente);
                    if (!validatorResult.IsValid) return StatusCode(StatusCodes.Status400BadRequest, this.service.validationErrors(validatorResult) + $"Funcionario de CPF: {linha.Cpf}");

                    this.service.Add(expediente);
                }

                ModalidadeContrato modalidadeContrato = this.service.AddModalidadeContrato(linha.ModalidadeContrato);
                if (modalidadeContrato == null && !String.IsNullOrEmpty(linha.ModalidadeContrato))
                {
                    modalidadeContrato = new ModalidadeContrato();
                    modalidadeContrato.Nome = linha.ModalidadeContrato;

                    ModalidadeContratoValidator modalidadeContratoValidator = new();
                    var validatorResult = modalidadeContratoValidator.Validate(modalidadeContrato);
                    if (!validatorResult.IsValid) return StatusCode(StatusCodes.Status400BadRequest, this.service.validationErrors(validatorResult) + $"Funcionario de CPF: {linha.Cpf}");
                    this.service.Add(modalidadeContrato);
                }

                Contrato contrato = this.service.AddContrato(funcionario, cargo, expediente, modalidadeContrato, linha.InicioContrato, linha.FimContrato);

                if (contrato == null && linha.InicioContrato != default(DateTime))
                {
                    contrato = new Contrato();
                    contrato.FuncionarioId = funcionario.Id;
                    contrato.CargoId = cargo.Id;
                    contrato.ExpedienteId = expediente.Id;
                    contrato.ModalidadeContratoId = modalidadeContrato.Id;
                    contrato.DataInicio = linha.InicioContrato;
                    contrato.DataFim = linha.FimContrato;

                    ContratoValidator contratoValidator = new();
                    var validatorResult = contratoValidator.Validate(contrato);
                    if (!validatorResult.IsValid) return StatusCode(StatusCodes.Status400BadRequest, this.service.validationErrors(validatorResult) + $"Funcionario de CPF: {linha.Cpf}");

                    this.service.Add(contrato);
                }

                if (contrato == null) return this.StatusCode(StatusCodes.Status400BadRequest,$"Dados insuficientes para registrar funcionario de cpf {funcionario.Cpf}"); 
            
                if (linha.RegistroPonto != default(DateTime)){
                    try{
                        this.service.AddRegistroPonto(linha.RegistroPonto, funcionario.Id);
                    }catch{
                        return this.StatusCode(StatusCodes.Status400BadRequest,$"Formato de ponto inválido para o funcionário de cpf {funcionario.Cpf}"); 
                    }
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