using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Entities
{
    public class Produto
    {
        string _descricao = string.Empty;

        public int ProdutoId { get; set; }
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
        public decimal Preco { get; set; }
        public double Estoque { get; set; }
    }
}
