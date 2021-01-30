using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Entities
{
    public class SaidaDeCaixa
    {
        public SaidaDeCaixa(decimal valorTotal, decimal valorPago, decimal valorTroco, string detalhesTroco, DateTime dataTransacao)
        {
            ValorTotal = valorTotal;
            ValorPago = valorPago;
            ValorTroco = valorTroco;
            DetalhesTroco = detalhesTroco;
            DataTransacao = dataTransacao;
        }

        //contrutor para o dapper
        private SaidaDeCaixa()
        {

        }

        public int Id { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorPago { get; private set; }
        public decimal ValorTroco { get; private set; }
        public string DetalhesTroco { get; private set; }
        public DateTime DataTransacao { get; private set; }
    }
}
