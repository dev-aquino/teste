using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class PdvTests : BaseTest
    {

        [TestMethod]
        [DataRow(90, 100)]
        public void DEVE_RETORNAR_COMO_TROCO_UMA_NOTA_DE_DEZ(dynamic param01, dynamic param02)
        {
            var resultMethod = _pdvService.GerarTroco(Convert.ToDecimal(param01), Convert.ToDecimal(param02));
            var result = resultMethod.InformativoTroco == "Entregar 1 nota(s) de R$10 / ";

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(99.73, 100)]
        public void DEVE_RETORNAR_COMO_TROCO_DUAS_MOEDAS_DE_DEZ_UMA_DE_CINCO_E_DUAS_DE_UM(dynamic param01, dynamic param02)
        {
            var resultMethod = _pdvService.GerarTroco(Convert.ToDecimal(param01), Convert.ToDecimal(param02));
            var result = resultMethod.InformativoTroco == "Entregar 2 moeda(s) de R$0,01 / 1 moeda(s) de R$0,05 / 2 moeda(s) de R$0,1 / ";

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(40, 50)]
        public void VERIFICA_SE_A_SAIDA_DE_CAIXA_FOI_PERSISTIDA(dynamic param01, dynamic param02)
        {
            var valorTroco = Decimal.Round(Convert.ToDecimal(param02 - param01), 2);
            var resultMethod1 = _pdvService.GerarTroco(param01, param02);
            var resultMethod2 = _pdvService.ConsultarTransacoesDeTroco();
            var result = resultMethod2.Transacoes.Any(x => x.ValorTotal == param01 && x.ValorPago == param02 && x.ValorTroco == valorTroco);

            Assert.IsTrue(result);
        }
    }
}
