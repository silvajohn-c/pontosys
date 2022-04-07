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
            var results = new ExcelMapper(file.OpenReadStream()).Fetch<XlsModel>();

            foreach (var registro in results)
            {
                if (!(registro.Cpf == default(long))){
                    Funcionario funcionario = this.service.GetFuncionarioByCpf(registro.Cpf);

                        if (funcionario == null)
                        {
                            funcionario = new Funcionario();
                            funcionario.Nome = registro.Nome;
                            funcionario.Sobrenome = registro.Sobrenome;
                            funcionario.Cpf = registro.Cpf;
                            this.service.Add(funcionario);
                        }
                    

                    Cargo cargo = this.service.GetCargoByName(registro.Cargo);

                    if (cargo == null)
                    {
                        cargo = new Cargo();
                        cargo.Nome = registro.Cargo;
                        this.service.Add(cargo);
                    }

                    Expediente expediente = this.service.GetExpedienteByValue(registro.CargaHoraria);

                    if (expediente == null)
                    {
                        expediente = new Expediente();
                        expediente.CargaHoraria = registro.CargaHoraria;
                        this.service.Add(expediente);
                    }

                    ModalidadeContrato modalidadeContrato = this.service.GetModalidadeContratoByName(registro.ModalidadeContrato);

                    if (modalidadeContrato == null)
                    {
                        modalidadeContrato = new ModalidadeContrato();
                        modalidadeContrato.Nome = registro.ModalidadeContrato;
                        this.service.Add(modalidadeContrato);
                    }

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
                    }

                    if (!(registro.Ocorrencia == null))
                    {

                        Ocorrencia ocorrencia = this.service.GetOcorrenciaByDate(registro.DataOcorrencia, funcionario.Id);

                        if (ocorrencia == null)
                        {
                            ocorrencia = new Ocorrencia();

                            ocorrencia.Data = registro.DataOcorrencia;
                            ocorrencia.Descricao = registro.Ocorrencia;
                            ocorrencia.FuncionarioId = funcionario.Id;
                            
                            TipoOcorrencia tipoOcorrencia = this.service.GetTipoOcorrenciaByDescricao(registro.TipoOcorrencia);
                            
                            if (tipoOcorrencia == null)
                            {
                                tipoOcorrencia = new TipoOcorrencia();
                                tipoOcorrencia.Descricao = registro.TipoOcorrencia;
                                this.service.Add(tipoOcorrencia);
                            }

                            ocorrencia.TipoOcorrenciaId = tipoOcorrencia.Id;

                            StatusOcorrencia statusOcorrencia = this.service.GetStatusOcorrenciaByName(registro.StatusOcorrencia);

                            if (statusOcorrencia == null)
                            {
                                statusOcorrencia = new StatusOcorrencia();
                                statusOcorrencia.Nome = registro.StatusOcorrencia;
                                this.service.Add(statusOcorrencia);
                            }

                            ocorrencia.StatusOcorrenciaId = statusOcorrencia.Id;

                            this.service.Add(ocorrencia);
                        }
                    }
            
                    if (!(registro.RegistroPonto == default(DateTime)))
                    {
                    RegistroPonto registroPonto = this.service.GetRegistroPontoDate(registro.RegistroPonto);

                    if (registroPonto == null)
                        {
                            registroPonto = new RegistroPonto();
                            registroPonto.CreatedAt = registro.RegistroPonto;
                            registroPonto.FuncionarioId = funcionario.Id;
                            this.service.Add(registroPonto);
                        }
                    }

                    if (!(registro.HoraExtra == default(int)))
                    {
                    HoraExtra horaExtra = this.service.GetHoraExtra(registro.DataHoraExtra, funcionario.Id);
                        
                        if (horaExtra == null)
                        {
                            horaExtra = new HoraExtra();
                            horaExtra.CreatedAt = registro.DataHoraExtra;
                            horaExtra.Quantidade = registro.HoraExtra;
                            horaExtra.FuncionarioId = funcionario.Id;
                            
                            ModalidadeHoraExtra modalidadeHoraExtra = this.service.GetModalidadeHoraExtraByValue(registro.ModalidadeHoraExtra);
                            if (modalidadeHoraExtra == null)
                            {
                                modalidadeHoraExtra = new ModalidadeHoraExtra();
                                modalidadeHoraExtra.Valor = registro.ModalidadeHoraExtra;
                                this.service.Add(modalidadeHoraExtra);
                            }

                            horaExtra.ModalidadeHoraExtraId = modalidadeHoraExtra.Id;

                            PeriodoHoraExtra periodoHoraExtra = this.service.GetPeriodoHoraExtraByDescricao(registro.PeriodoHoraExtra);
                            if (periodoHoraExtra == null)
                            {
                                periodoHoraExtra = new PeriodoHoraExtra();
                                periodoHoraExtra.Descricao = registro.PeriodoHoraExtra;
                                this.service.Add(periodoHoraExtra);
                            }

                            horaExtra.PeriodoHoraExtraId = periodoHoraExtra.Id;

                            this.service.Add(horaExtra);
                        }
                    }

                    try
                    {
                        await this.service.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        return this
                            .StatusCode(StatusCodes
                                .Status500InternalServerError,
                            $"Falha ao inserir os dados no banco: {ex.Message}");
                    }
                }
            }

            return Ok("Dados inseridos com sucesso!");
        }
    }
}
