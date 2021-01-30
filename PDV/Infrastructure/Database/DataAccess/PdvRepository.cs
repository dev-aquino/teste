using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Database.Contexts;
using Infrastructure.Database.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace Infrastructure.Database.DataAccess
{
    public class PdvRepository : IPdvRepository
    {
        private readonly SqlServerContext _context;
        private readonly IConfiguration _configuration;

        public PdvRepository(SqlServerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public void RegistrarSaidaDeCaixa(TransacaoDeTroco transacaoDeTroco)
        {
            var saidaDeCaixa = new SaidaDeCaixa(transacaoDeTroco.ValorTotal, transacaoDeTroco.ValorPago, transacaoDeTroco.ValorTroco, transacaoDeTroco.DetalhesTroco, transacaoDeTroco.DataTransacao);
            _context.SaidasDeCaixa.Add(saidaDeCaixa);
            _context.SaveChanges();
        }

        public IEnumerable<TransacaoDeTroco> ObterSaidasDeCaixa()
        {
            var resultEntities = Enumerable.Empty<SaidaDeCaixa>();

            using (SqlConnection conexao = new SqlConnection(_configuration.GetConnectionString("PdvConnection")))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM dbo.SaidasDeCaixa";
                    resultEntities = conexao.Query<SaidaDeCaixa>(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
            }
            
            var result = resultEntities.Select(x => new TransacaoDeTroco(x.ValorTotal, x.ValorPago, x.ValorTroco, x.DetalhesTroco, x.DataTransacao)).ToList();
            return result;
        }
    }
}
