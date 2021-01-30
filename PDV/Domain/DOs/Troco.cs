using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DOs
{
    public class Troco
    {
        public IDictionary<decimal, int> Notas { get; set; }
        public IDictionary<decimal, int> Moedas { get; set; }
    }
}
