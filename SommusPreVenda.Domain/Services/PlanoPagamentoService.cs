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
    public class PlanoPagamentoService
    {
        private readonly IDataContext _dataContext;
        private readonly IPlanoPagamentoRepository _planoPagamentoRepository;

        public ResponseService ResponseService { get; set; }

        private PlanoPagamentoService()
        {
            ResponseService = new ResponseService();
        }

        public PlanoPagamentoService(
            IDataContext dataContext,
            IPlanoPagamentoRepository planoPagamentoRepository)
        {
            _dataContext = dataContext;
            _planoPagamentoRepository = planoPagamentoRepository;
            ResponseService = new ResponseService();
        }

        public PlanoPagamento Get(int id)
        {
            var planoPagamento = new PlanoPagamento();
            try
            {
                _dataContext.BeginTransaction();
                planoPagamento = _planoPagamentoRepository.Get(id);
                if (planoPagamento.PlanoPagamentoId == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning,"Plano de Pagamento NULL");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Plano de Pagamento encontrada!");
                }
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar o Plano de Pagamento!");
            }
            finally
            {
                _dataContext.Finally();
            }

            return planoPagamento;
        }

        public List<PlanoPagamento> Get()
        {
            var planosPagamento = new List<PlanoPagamento>();
            try
            {
                _dataContext.BeginTransaction();
                planosPagamento = _planoPagamentoRepository.Get();

                if (planosPagamento.Count == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "Plano de Pagamento NULL");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Plano de Pagamentos encontradas!");
                }

            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar os Planos de Pagamentos!");
            }
            finally
            {
                _dataContext.Finally();
            }

            return planosPagamento;

        }

    }
}
