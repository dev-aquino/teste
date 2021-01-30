using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDVController : ControllerBase
    {
        private readonly IPdvService _pdvService;

        public PDVController(IPdvService pdvService)
        {
            _pdvService = pdvService;
        }

        [HttpPost("GeraTroco")]
        public GerarTrocoResponse GeraTroco([FromBody] GerarTrocoRequest gerarTrocoRequestDTO)
        {
            try
            {
                return _pdvService.GerarTroco(gerarTrocoRequestDTO.ValorTotal, gerarTrocoRequestDTO.ValorPago);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ConsultaTransacoesDeTroco")]
        public ConsultaTransacoesDeTrocoResponse ConsultaTransacoesDeTroco()
        {
            try
            {
                return _pdvService.ConsultarTransacoesDeTroco();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
