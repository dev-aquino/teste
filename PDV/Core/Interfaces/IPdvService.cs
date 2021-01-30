using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPdvService
    {
        GerarTrocoResponse GerarTroco(decimal valorTotal, decimal valorPago);

        ConsultaTransacoesDeTrocoResponse ConsultarTransacoesDeTroco();
    }
}
