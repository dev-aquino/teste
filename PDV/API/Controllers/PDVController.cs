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
        public ActionResult<GerarTrocoResponse> GeraTroco([FromBody] GerarTrocoRequest gerarTrocoRequestDTO)
        {
            try
            {
                var response = _pdvService.GerarTroco(gerarTrocoRequestDTO.ValorTotal, gerarTrocoRequestDTO.ValorPago);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ConsultaTransacoesDeTroco")]
        public ActionResult<ConsultaTransacoesDeTrocoResponse> ConsultaTransacoesDeTroco()
        {
            try
            {
                var response = _pdvService.ConsultarTransacoesDeTroco();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
