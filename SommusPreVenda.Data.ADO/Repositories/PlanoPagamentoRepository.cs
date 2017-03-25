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
    public class PlanoPagamentoRepository: IPlanoPagamentoRepository
    {
        public PlanoPagamento Get(int planoPagamentoId)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM srv_planos_pagamento ");
            query.Append(" WHERE                              ");
            query.Append(" ppg_codigo=?codigo AND ppg_ativo=1 ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?codigo", planoPagamentoId);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var planoPagamento = new PlanoPagamento()
                {
                    PlanoPagamentoId = Convert.ToInt32(row["ppg_codigo"]),
                    Descricao = row["ppg_descricao"].ToString()
                };
                return planoPagamento;
            }

            return new PlanoPagamento();
        }

        public List<PlanoPagamento> Get()
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM srv_planos_pagamento ");
            query.Append(" WHERE                              ");
            query.Append(" ppg_ativo=1                        ");
            var mySqlCommand = new MySqlCommand(query.ToString(), 
                DataContext.MySqlConnection, 
                DataContext.MySqlTransaction);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var planosPagamento = new List<PlanoPagamento>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    var planoPagamento = new PlanoPagamento()
                    {
                        PlanoPagamentoId = Convert.ToInt32(row["ppg_codigo"]),
                        Descricao = row["ppg_descricao"].ToString()
                    };
                    planosPagamento.Add(planoPagamento);
                }
                return planosPagamento;
            }
            return new List<PlanoPagamento>();
        }

    }
}
