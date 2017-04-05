using System;
using System.Collections.Generic;

namespace SommusPreVenda.Domain.Entities
{
    public class PreVenda
    {
        string _nomeComputador = string.Empty;
        Usuario _usuario = new Usuario();
        Usuario _concedeuDesconto = new Usuario();
        Cliente _cliente = new Cliente();
        PlanoPagamento _planoPagamento = new PlanoPagamento();
        List<PreVendaItem> _preVendaItens = new List<PreVendaItem>();

        public int PreVendaId { get; set; }
        public ulong NumeroDAVPreVenda { get; set; }
        public string NomeComputador
        {
            get
            {
                return _nomeComputador ?? string.Empty;
            }
            set
            {
                _nomeComputador = value;
            }
        }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public int QuantidadeItens { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }        
        public Usuario Usuario
        {
            get
            {
                return _usuario ?? new Usuario();
            }
            set
            {
                _usuario = value;
            }
        }
        public Usuario ConcedeuDesconto
        {
            get
            {
                return _concedeuDesconto ?? new Usuario();
            }
            set
            {
                _concedeuDesconto = value;
            }
        }
        public Cliente Cliente
        {
            get
            {
                return _cliente ?? new Cliente();
            }
            set
            {
                _cliente = value;
            }
        }        
        public PlanoPagamento PlanoPagamento
        {
            get
            {
                return _planoPagamento ?? new PlanoPagamento();
            }
            set
            {
                _planoPagamento = value;
            }
        }
        public List<PreVendaItem> PreVendaItens
        {
            get
            {
                return _preVendaItens ?? new List<PreVendaItem>();
            }
            set
            {
                _preVendaItens = value;
            }
        }

    }
}
