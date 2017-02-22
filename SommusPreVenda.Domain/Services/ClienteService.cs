using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Services
{
    public class ClienteService
    {
        public ResponseService ResponseService { get; set; }

        private ClienteService()
        {
            ResponseService = new ResponseService();
        } 

    }
}
