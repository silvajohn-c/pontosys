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
            var planilha = new ExcelMapper(file.OpenReadStream()).Fetch<XlsModel>();

            foreach (var linha in planilha)
            {
                if (linha.Cpf != default(long))
                {
                    Funcionario funcionario = this.service.AddFuncionario(linha.Cpf, linha.Nome, linha.Sobrenome);

                    Cargo cargo = this.service.AddCargo(linha.Cargo);

                    Expediente expediente = this.service.AddExpediente(linha.CargaHoraria);

                    ModalidadeContrato modalidadeContrato = this.service.AddModalidadeContrato(linha.ModalidadeContrato);

                    Contrato contrato = this.service.AddContrato(funcionario, cargo, expediente, modalidadeContrato, linha.InicioContrato, linha.FimContrato);

                    if (contrato == null) return this.StatusCode(StatusCodes.Status400BadRequest,$"Dados insuficientes para registrar funcionaro de cpf {funcionario.Cpf}"); 
                    
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