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
    public static class PlanoPagamentoApplication
    {
        public static readonly PlanoPagamentoService _planoPagamentoService = new PlanoPagamentoService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IPlanoPagamentoRepository>()
            );

        public static string ResponseMessage
        {
            get
            {
                return _planoPagamentoService.ResponseService.Message;
            }
        }
        public static string ResponseType
        {
            get
            {
               return _planoPagamentoService.ResponseService.Type.ToString();
            }
        }

        public static PlanoPagamentoVM Get(int id)
        {
            var planoPagamento = _planoPagamentoService.Get(id);
            var planoPagamentoVM = new MapperConfiguration(x =>
            {
                x.CreateMap<PlanoPagamento, PlanoPagamentoVM>();
            })
            .CreateMapper()
            .Map<PlanoPagamento, PlanoPagamentoVM>(planoPagamento);

            return planoPagamentoVM;
        }

        public static List<PlanoPagamentoVM> Get()
        {
            var planosPagamento = _planoPagamentoService.Get();
            var planosPagamentosVM = new MapperConfiguration(x =>
            {
                x.CreateMap<PlanoPagamento, PlanoPagamentoVM>();
            })
            .CreateMapper()
            .Map<List<PlanoPagamento>, List<PlanoPagamentoVM>>(planosPagamento);

            return planosPagamentosVM;
        }
    }
}
