using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPdvRepository
    {
        void RegistrarSaidaDeCaixa(TransacaoDeTroco transacaoDeTroco);

        IEnumerable<TransacaoDeTroco> ObterSaidasDeCaixa();
    }
}
