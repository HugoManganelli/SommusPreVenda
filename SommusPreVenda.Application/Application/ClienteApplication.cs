﻿using AutoMapper;
using SommusPreVenda.Application.DependencyInjection.Services;
using SommusPreVenda.Application.ViewModels.Cliente;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Repositories;
using SommusPreVenda.Domain.Services;
using System.Collections.Generic;

namespace SommusPreVenda.Application.Application
{
    public static class ClienteApplication
    {
        private static readonly ClienteService _clienteService = new ClienteService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IClienteRepository>()
            );

        public static string ResponseMessage
        {
            get
            {
                return _clienteService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _clienteService.ResponseService.Type.ToString();
            }
        }
        
        public static ClienteVM Get(int id)
        {
            var cliente = _clienteService.Get(id);
            var clienteVM = Mapper.Map<Cliente, ClienteVM>(cliente);

            return clienteVM;
        }

        public static List<ClienteVM> Get(string pesquisa)
        {
            var clientes = _clienteService.Get(pesquisa);
            List<ClienteVM> clientesVM = Mapper.Map<List<Cliente>, List<ClienteVM>>(clientes);

            return clientesVM;
        }
    }
}
