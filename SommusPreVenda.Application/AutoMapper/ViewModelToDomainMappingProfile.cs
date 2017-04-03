using AutoMapper;
using SommusPreVenda.Application.ViewModels.Cliente;
using SommusPreVenda.Application.ViewModels.PreVenda;
using SommusPreVenda.Application.ViewModels.PreVendaItem;
using SommusPreVenda.Domain.Entities;
using System.Collections.Generic;

namespace SommusPreVenda.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PreVendaVM, PreVenda>();
            CreateMap<ClientePreVendaVM, Cliente>();
            CreateMap<PlanoPagamentoPreVendaVM, PlanoPagamento>();
            CreateMap<UsuarioPreVendaVM, Usuario>();
            CreateMap<PreVendaItemVM, PreVendaItem>();
            CreateMap<ProdutoPreVendaItemVM, Produto>();

        }
    }
}
