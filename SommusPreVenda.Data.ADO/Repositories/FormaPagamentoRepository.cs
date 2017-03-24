using MySql.Data.MySqlClient;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class FormaPagamentoRepository: IFormaPagamentoRepository
    {
        public FormaPagamento Get(int formapagamentoId)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM srv_formas_pagamento ");
            query.Append(" WHERE                              ");
            query.Append(" fpg_codigo=?codigo AND fpg_ativo=1 ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?codigo", formapagamentoId);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var formaPagamento = new FormaPagamento()
                {
                    FormaPagamentoId = Convert.ToInt32(row["fpg_codigo"]),
                    Descricao = row["fpg_descricao"].ToString()
                };
                return formaPagamento;
            }

            return new FormaPagamento();
        }

        public List<FormaPagamento> Get()
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM srv_formas_pagamento ");
            query.Append(" WHERE                              ");
            query.Append(" fpg_ativo=1                        ");
            var mySqlCommand = new MySqlCommand(query.ToString(), 
                DataContext.MySqlConnection, 
                DataContext.MySqlTransaction);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var formasPagamentos = new List<FormaPagamento>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    var formaPagamento = new FormaPagamento()
                    {
                        FormaPagamentoId = Convert.ToInt32(row["fpg_codigo"]),
                        Descricao = row["fpg_descricao"].ToString()
                    };
                    formasPagamentos.Add(formaPagamento);
                }
                return formasPagamentos;
            }
            return new List<FormaPagamento>();
        }

    }
}
