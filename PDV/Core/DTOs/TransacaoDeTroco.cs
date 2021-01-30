using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class TransacaoDeTroco
    {
        public TransacaoDeTroco(decimal valorTotal, decimal valorPago, decimal valorTroco, string detalhesTroco, DateTime dataTransacao)
        {
            ValorTotal = valorTotal;
            ValorPago = valorPago;
            ValorTroco = valorTroco;
            DetalhesTroco = detalhesTroco;
            DataTransacao = dataTransacao;
        }

        public decimal ValorTotal { get; private set; }
        public decimal ValorPago { get; private set; }
        public decimal ValorTroco { get; private set; }
        public string DetalhesTroco { get; private set; }
        public DateTime DataTransacao { get; private set; }
    }
}
