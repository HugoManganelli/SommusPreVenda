using AutoMapper;
using SommusPreVenda.Application.DependencyInjection.Services;
using SommusPreVenda.Application.ViewModels.Produto;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Repositories;
using SommusPreVenda.Domain.Services;
using System.Collections.Generic;

namespace SommusPreVenda.Application.Application
{
    public static class ProdutoApplication
    {
        private static readonly ProdutoService _produtoService = new ProdutoService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IProdutoRepository>()
            );

        public static string ResponseMessage
        {
            get
            {
                return _produtoService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _produtoService.ResponseService.Type.ToString();
            }
        }

        public static ProdutoVM Get(int id)
        {
            var produto = _produtoService.Get(id);
            var produtoVM = Mapper.Map<Produto, ProdutoVM>(produto);

            return produtoVM;
        }

        public static List<ProdutoVM> Get(string pesquisa)
        {
            var produtos = _produtoService.Get(pesquisa);
            var produtosVM = Mapper.Map<List<Produto>, List<ProdutoVM>>(produtos);

            return produtosVM;
        }
    }
}
