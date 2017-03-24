using AutoMapper;
using SommusPreVenda.Application.DependencyInjection.Services;
using SommusPreVenda.Application.ViewModels.FormaPagamento;
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
    public static class FormaPagamentoApplication
    {
        public static readonly FormaPagamentoService _formapagamentoService = new FormaPagamentoService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IFormaPagamentoRepository>()
            );

        public static string ResponseMessage
        {
            get
            {
                return _formapagamentoService.ResponseService.Message;
            }
        }
        public static string ResponseType
        {
            get
            {
               return _formapagamentoService.ResponseService.Type.ToString();
            }
        }

        public static FormaPagamentoVM Get(int id)
        {
            var formaPagamento = _formapagamentoService.Get(id);
            var formaPagamentoVM = new MapperConfiguration(x =>
            {
                x.CreateMap<FormaPagamento, FormaPagamentoVM>();
            })
            .CreateMapper()
            .Map<FormaPagamento, FormaPagamentoVM>(formaPagamento);

            return formaPagamentoVM;
        }

        public static List<FormaPagamentoVM> Get()
        {
            var formasPagamentos = _formapagamentoService.Get();
            var formasPagamentosVM = new MapperConfiguration(x =>
            {
                x.CreateMap<FormaPagamento, FormaPagamentoVM>();
            })
            .CreateMapper()
            .Map<List<FormaPagamento>, List<FormaPagamentoVM>>(formasPagamentos);

            return formasPagamentosVM;
        }
    }
}
