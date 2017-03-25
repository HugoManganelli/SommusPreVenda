using SommusPreVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Interfaces.Repositories
{
    public interface IPreVendaRepository
    {
        void Add(PreVenda preVenda);
    }
}
