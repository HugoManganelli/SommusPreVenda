using AutoMapper;
using SommusPreVenda.Application.ViewModels.Cliente;
using SommusPreVenda.Application.ViewModels.FormaPagamento;
using SommusPreVenda.Application.ViewModels.PreVenda;
using SommusPreVenda.Application.ViewModels.Produto;
using SommusPreVenda.Application.ViewModels.Usuario;
using SommusPreVenda.Domain.Entities;
using System.Collections.Generic;

namespace SommusPreVenda.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteVM>();
            CreateMap<List<Cliente>, List<ClienteVM>>();
            CreateMap<PlanoPagamento, PlanoPagamentoVM>();
            CreateMap<List<PlanoPagamento>, List<PlanoPagamentoVM>>();
            CreateMap<Produto, ProdutoVM>();
            CreateMap<List<Produto>, List<ProdutoVM>>();
            CreateMap<Usuario, UsuarioVM>();
        }
    }
}
