using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Contexts
{
    public class SqlServerContext : DbContext
    {
        public DbSet<SaidaDeCaixa> SaidasDeCaixa { get; set; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }
    }
}
