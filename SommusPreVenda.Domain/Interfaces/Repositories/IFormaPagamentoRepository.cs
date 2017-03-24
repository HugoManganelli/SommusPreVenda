using SommusPreVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Interfaces.Repositories
{
    public interface IFormaPagamentoRepository
    {
        FormaPagamento Get(int formapagamentoId);
        List<FormaPagamento> Get();
    }
}
