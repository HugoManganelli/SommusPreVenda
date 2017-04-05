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
    public class ProdutoService
    {
        private readonly IDataContext _dataContext;
        private readonly IProdutoRepository _produtoRepository;

        public ResponseService ResponseService { get; set; } 

        private ProdutoService()
        {
            ResponseService = new ResponseService();
        }

        public ProdutoService(
            IDataContext dataContext, 
            IProdutoRepository produtoRepository)
        {
            _dataContext = dataContext;
            _produtoRepository = produtoRepository;
            ResponseService = new ResponseService();
        }

        public Produto Get(int id)
        {
            var produto = new Produto();

            try
            {
                _dataContext.BeginTransaction();
                produto = _produtoRepository.Get(id);
                if(produto.ProdutoId == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "O produto não foi localizado!");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "O produto foi encontrado!");
                }
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar o produto.");
            }
            finally
            {
                _dataContext.Finally();
            }

            return produto;
        }

        public List<Produto> Get(string pesquisa)
        {
            var produtos = new List<Produto>();

            try
            {
                _dataContext.BeginTransaction();
                produtos = _produtoRepository.Get(pesquisa);

                if (produtos.Count == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "Lista de produtos vazia!");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Lista cheia!");
                }
            }catch (Exception ex)
            {
                    ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao listar produtos.");
            }
            finally
            {
                _dataContext.Finally();
            }

            return produtos;
        }
    }
}
