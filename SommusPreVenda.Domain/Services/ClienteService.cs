using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Enums;
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

        public ClienteService(
            IDataContext dataContext,
            IClienteRepository clienteRepository)
        {
            _dataContext = dataContext;
            _clienteRepository = clienteRepository;
            ResponseService = new ResponseService();
        }

        public Cliente Get(int id)
        {
            var cliente = new Cliente();
            try
            {
                _dataContext.BeginTransaction();
                cliente = _clienteRepository.Get(id);
                if (cliente.ClienteId == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "Cliente NULL");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Cliente consultado");
                }
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar o cliente.");
            }
            finally
            {
                _dataContext.Finally();
            }

            return cliente;
        }

        public List<Cliente> Get()
        {
            var clientes = new List<Cliente>();
            try
            {
                _dataContext.BeginTransaction();
                clientes = _clienteRepository.Get();

                if (clientes.Count == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "Lista vazia!");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Lista preenchida!");
                }
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar a lista clientes.");
            }
            finally
            {
                _dataContext.Finally();
            }
            return clientes;
        }
    }
}
