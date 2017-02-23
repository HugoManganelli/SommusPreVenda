using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Services
{
    public class ClienteService
    {
        private readonly IDataContext _dataContext;
        private readonly IClienteRepository _clienteRepository;

        public ResponseService ResponseService { get; set; }

        private ClienteService()
        {
            ResponseService = new ResponseService();
        } 

        public ClienteService(IDataContext dataContext, IClienteRepository clienteRepository)
        {
            _dataContext = dataContext;
            _clienteRepository = clienteRepository;
            ResponseService = new ResponseService();            
        }
        
    }
}
