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
            CreateMap<PlanoPagamento, PlanoPagamentoVM>();
            CreateMap<Produto, ProdutoVM>();
            CreateMap<Usuario, UsuarioVM>();
        }
    }
}
