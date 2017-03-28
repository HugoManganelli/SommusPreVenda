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

        ulong GetNumeroDAVPreVenda();

        void AddContadorDAV();

        void UpdateContadorDAV(ulong numeroPreVenda);

        void TravaTabelaContador();

        void DestravaTabelaContador();
    }
}
