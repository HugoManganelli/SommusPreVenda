using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Entities
{
    public class PlanoPagamento
    {
        string _descricao = string.Empty;

        public int PlanoPagamentoId { get; set; }
        public string Descricao
        {
            get
            {
                return _descricao ?? string.Empty;
            }
            set
            {
                _descricao = value;
            }
        }
    }
}
