using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ConsultaTransacoesDeTrocoResponse : BaseResponse
    {
        public IEnumerable<TransacaoDeTroco> Transacoes { get; set; }
    }
}
