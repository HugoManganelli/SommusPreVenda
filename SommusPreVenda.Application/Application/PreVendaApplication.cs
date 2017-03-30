using AutoMapper;
using SommusPreVenda.Application.DependencyInjection.Services;
using SommusPreVenda.Application.ViewModels.PreVenda;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Repositories;
using SommusPreVenda.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Application.Application
{
    public static class PreVendaApplication
    {
        private static readonly PreVendaService _preVendaService = new PreVendaService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IPreVendaRepository>(),
            DependencyInjectionService.Resolve<IPreVendaItemRepository>());

        public static string ResponseMessage
        {
            get
            {
                return _preVendaService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _preVendaService.ResponseService.Type.ToString();
            }
        }

        public static void Add(PreVendaVM preVendaVM)
        {
            var preVenda = Mapper.Map<PreVendaVM, PreVenda>(preVendaVM);
            _preVendaService.Add(preVenda);
        }
    }
}
