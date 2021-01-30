using Application.DTOs;
using Application.Interfaces;
using Domain.DOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PdvService : IPdvService
    {
        private readonly IList<decimal> _listaNotasEMoedas = new List<decimal> { 0.01m, 0.05m, 0.1m, 0.5m, 10m, 20m, 50m, 100m };
        private decimal valoreRestante = 0;

        public GerarTrocoResponse GerarTroco(decimal valorTotal, decimal valorPago)
        {
            var result = new GerarTrocoResponse();
            result.InformativoValorTotal = $"Valor total a ser pago: {valorTotal}";
            result.InformativoValorPago = $"Valor efetivamente pago: {valorPago}";

            if (valorPago < valorTotal)
            {
                result.Notificacao = "O valor pago deve ser igual ou maior que o valor total";
            }

            var valorParaTroco = valorPago - valorTotal;
            if (valorParaTroco == 0)
            {
                result.Notificacao = "Não precisa de troco";
            }

            var dicionarioDeTroco = PrepararDicionarioDeTroco(_listaNotasEMoedas);
            GerarTrocoParcial(valorParaTroco, ref dicionarioDeTroco, _listaNotasEMoedas.OrderByDescending(x => x).ToList());
            var resultTroco = dicionarioDeTroco.Where(x => x.Value > 0).ToDictionary(y => y.Key, z => z.Value);

            var troco = new Troco
            {
                Moedas = resultTroco.Where(x => x.Key < 10).ToDictionary(y => y.Key, z => z.Value),
                Notas = resultTroco.Where(x => x.Key >= 10).ToDictionary(y => y.Key, z => z.Value)
            };
            
            result.InformativoTroco = GerarInformativoTroco(troco);

            return result;
        }

        #region privados

        private IDictionary<decimal, int> PrepararDicionarioDeTroco(IList<decimal> listaNotasEMoedas)
        {
            var result = new Dictionary<decimal, int>();

            foreach (var item in listaNotasEMoedas)
            {
                result.Add(item, 0);
            }
            return result;
        }

        private void GerarTrocoParcial(decimal valorParaTroco, ref IDictionary<decimal, int> dicionarioDeTroco, IList<decimal> listaNotasEMoedas)
        {
            valoreRestante = Decimal.Round(valorParaTroco, 2);
            if (valoreRestante > 0)
            {
                foreach (var item in listaNotasEMoedas)
                {
                    if (item <= valoreRestante && valoreRestante != 0)
                    {
                        valoreRestante -= item;
                        dicionarioDeTroco[item] += 1;
                        if (valoreRestante > 0)
                        {
                            GerarTrocoParcial(valoreRestante, ref dicionarioDeTroco, listaNotasEMoedas);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        private string GerarInformativoTroco(Troco troco)
        {
            var result = "Entregar ";
            foreach (var nota in troco.Notas)
            {
                result += $"{nota.Value} nota(s) de R${nota.Key} / ";
            }

            foreach (var moeda in troco.Moedas)
            {
                result += $"{moeda.Value} moeda(s) de R${moeda.Key} / ";
            }

            return result;
        }

        #endregion
    }
}
