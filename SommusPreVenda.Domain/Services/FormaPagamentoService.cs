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
    public class FormaPagamentoService
    {
        private readonly IDataContext _dataContext;
        private readonly IFormaPagamentoRepository _formapagamentoRepository;

        public ResponseService ResponseService { get; set; }

        private FormaPagamentoService()
        {
            ResponseService = new ResponseService();
        }

        public FormaPagamentoService(
            IDataContext dataContext,
            IFormaPagamentoRepository formapagamentoRepository)
        {
            _dataContext = dataContext;
            _formapagamentoRepository = formapagamentoRepository;
            ResponseService = new ResponseService();
        }

        public FormaPagamento Get(int id)
        {
            var formapagamento = new FormaPagamento();
            try
            {
                _dataContext.BeginTransaction();
                formapagamento = _formapagamentoRepository.Get(id);
                if (formapagamento.FormaPagamentoId == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning,"Forma Pagamento NULL");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success,"Forma Pagamento encontrada!");
                }
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error,"Erro ao consultar a forma de pagamento!");
            }
            finally
            {
                _dataContext.Finally();
            }

            return formapagamento;
        }

        public List<FormaPagamento> Get()
        {
            var formaspagamentos = new List<FormaPagamento>();
            try
            {
                _dataContext.BeginTransaction();
                formaspagamentos = _formapagamentoRepository.Get();

                if (formaspagamentos.Count == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "Forma Pagamento NULL");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Formas Pagamentos encontradas!");
                }

            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar as formas de pagamentos!");
            }
            finally
            {
                _dataContext.Finally();
            }

            return formaspagamentos;

        }

    }
}
