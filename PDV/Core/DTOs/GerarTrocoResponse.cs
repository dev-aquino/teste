using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class GerarTrocoResponse : BaseResponse
    {
        public string InformativoValorTotal { get; set; }
        public string InformativoValorPago { get; set; }
        public string InformativoTroco { get; set; }
    }
}
