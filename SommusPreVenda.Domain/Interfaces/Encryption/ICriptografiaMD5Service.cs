using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Interfaces.Encryption
{
    public interface ICriptografiaMD5Service
    {
        string CriptografaMD5(string texto);
    }
}
