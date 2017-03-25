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
    public class PreVendaService
    {
        private readonly IDataContext _dataContext;
        private readonly IPreVendaRepository _preVendaRepository;
        private readonly IPreVendaItemRepository _preVendaItemRepository;
        
        public ResponseService ResponseService { get; set; }
        
        private PreVendaService()
        {
            ResponseService = new ResponseService();
        } 

        public PreVendaService(
            IDataContext dataContext,
            IPreVendaRepository preVendaRepository,
            IPreVendaItemRepository preVendaItemRepository)
        {
            _dataContext = dataContext;
            _preVendaRepository = preVendaRepository;
            _preVendaItemRepository = preVendaItemRepository;
            ResponseService = new ResponseService();
        }

        public void Add(PreVenda preVenda)
        {
            try
            {
                _dataContext.BeginTransaction();

                if (ValidaPreVenda(preVenda))
                {
                    _preVendaRepository.Add(preVenda); 
                }

                var preVendaItens = preVenda.PreVendaItens;
                for (var i = 0; i < preVendaItens.Count; i++)
                {
                    preVendaItens[i].PreVendaId = preVenda.PreVendaId;
                    preVendaItens[i].Registro = i + 1;

                    _preVendaItemRepository.Add(preVendaItens[i]);
                }

                _dataContext.Commit();
                ResponseService = new ResponseService(ResponseTypeEnum.Success, "Pré-venda cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                _dataContext.Rollback();
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao cadastrar pré-venda.");
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        private bool ValidaPreVenda(PreVenda preVenda)
        {
            var preVendaItensResponse = new ResponseService();
            if (preVenda.PreVendaItens.Any(x => !ValidaPreVendaItem(x)))
            {
                preVendaItensResponse.Message = "Informe os itens da Pre-Venda Corretamente!";
            }

            ResponseService = new ResponseService();
            ResponseService.Message += preVendaItensResponse.Message;
            if (preVenda.Usuario.UsuarioId == 0)
            {
                ResponseService.FieldsInvalids.Add("Usuario");
            }
            if (preVenda.Cliente.ClienteId == 0)
            {
                ResponseService.FieldsInvalids.Add("Cliente");
            }
            if (preVenda.PlanoPagamento.PlanoPagamentoId == 0)
            {
                ResponseService.FieldsInvalids.Add("PlanoPagamento");
            }
            if (preVenda.PreVendaItens.Count == 0)
            {
                ResponseService.FieldsInvalids.Add("PreVendaItens");
            }
            if (ResponseService.FieldsInvalids.Count > 0)
            {
                ResponseService.Message += "Informe os dados da Pre-Venda corretamente!";
            }
            ResponseService.Type =
                string.IsNullOrEmpty(ResponseService.Message) ?
                ResponseTypeEnum.Success :
                ResponseTypeEnum.Warning;

            return ResponseService.Type == ResponseTypeEnum.Success;
        }

        private bool ValidaPreVendaItem(PreVendaItem preVendaItem)
        {
            ResponseService = new ResponseService();
            if (preVendaItem.Quantidade <= 0)
            {
                ResponseService.FieldsInvalids.Add("Quantidade");
            }
            if (preVendaItem.PrecoUnitario <= 0)
            {
                ResponseService.FieldsInvalids.Add("PrecoUnitario");
            }
            if (preVendaItem.Produto.ProdutoId == 0)
            {
                ResponseService.FieldsInvalids.Add("Produto");
            }
            if (ResponseService.FieldsInvalids.Count > 0)
            {
                ResponseService.Message += "Informe os dados corretamente";
            }
            ResponseService.Type =
                string.IsNullOrEmpty(ResponseService.Message) ?
                ResponseTypeEnum.Success :
                ResponseTypeEnum.Warning;
            
            return ResponseService.Type == ResponseTypeEnum.Success;
        }
    }
}
