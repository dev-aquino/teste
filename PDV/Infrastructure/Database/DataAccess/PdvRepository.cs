using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Database.Contexts;
using Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Database.DataAccess
{
    public class PdvRepository : IPdvRepository
    {
        private readonly SqlServerContext _context;

        public PdvRepository(SqlServerContext context)
        {
            _context = context;
        }


        public void RegistrarSaidaDeCaixa(TransacaoDeTroco transacaoDeTroco)
        {
            var saidaDeCaixa = new SaidaDeCaixa(transacaoDeTroco.ValorTotal, transacaoDeTroco.ValorPago, transacaoDeTroco.ValorTroco, transacaoDeTroco.DetalhesTroco, transacaoDeTroco.DataTransacao);
            _context.SaidasDeCaixa.Add(saidaDeCaixa);
            _context.SaveChanges();
        }

        public IEnumerable<TransacaoDeTroco> ObterSaidasDeCaixa()
        {
            var resultEntities = _context.SaidasDeCaixa.ToList();
            var result = resultEntities.Select(x => new TransacaoDeTroco(x.ValorTotal, x.ValorPago, x.ValorTroco, x.DetalhesTroco, x.DataTransacao)).ToList();
            return result;
        }
    }
}
