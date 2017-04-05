using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Entities
{
    public class Cliente
    {
        string _nome = string.Empty;
        string _endereco = string.Empty;

        public int ClienteId { get; set; }
        public string Nome
        {
            get
            {
                return _nome ?? string.Empty;
            }
            set
            {
                _nome = value;
            }
        }
        public string Endereco
        {
            get
            {
                return _endereco ?? string.Empty;
            }
            set
            {
                _endereco = value;
            }
        }
    }
}
