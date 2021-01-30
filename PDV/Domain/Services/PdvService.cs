using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PdvService : IPdvService
    {
        public GerarTrocoResponse GerarTroco(decimal valorTotal, decimal valorPago)
        {
            var result = new GerarTrocoResponse();
            if (valorPago < valorTotal)
            {
                result.Notificacao = "O valor pago deve ser igual ou maior que o valor total";
            }

            var valorParaTroco = valorPago - valorTotal;
            if (valorParaTroco == 0)
            {
                result.Notificacao = "Não precisa de troco";
            }

            result.InformativoValorTotal = $"Valor total a ser pago: {valorTotal}";
            result.InformativoValorPago = $"Valor efetivamente pago: {valorPago}";
            result.InformativoTroco = $"Entregar 1 nota de R$20,00 e 1 nota de R$10,00"; //teste

            return result;
        }
    }
}
