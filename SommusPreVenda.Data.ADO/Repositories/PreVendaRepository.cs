using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SommusPreVenda.Domain.Entities;
using MySql.Data.MySqlClient;
using System.Data;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class PreVendaRepository : IPreVendaRepository
    {
        public void Add(PreVenda preVenda)
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO srv_prevendas   ");
            query.Append(" (                           ");
            query.Append(" pvd_numero_dav_pv,          ");
            query.Append(" pvd_nome_computador,        ");
            query.Append(" pvd_data,                   ");
            query.Append(" pvd_hora,                   ");
            query.Append(" pvd_operador,               ");
            query.Append(" pvd_cliente,                ");
            query.Append(" pvd_plano_pagamento,        ");
            query.Append(" pvd_valor,                  ");
            query.Append(" pvd_desconto,               ");
            query.Append(" pvd_quem_concedeu_desconto, ");
            query.Append(" pvd_itens                   ");  
            query.Append(" )                           ");
            query.Append(" VALUES                      ");
            query.Append(" (                           ");
            query.Append(" ?NumeroDAVPreVenda,         ");
            query.Append(" ?NomeComputador,            ");
            query.Append(" ?Data,                      ");
            query.Append(" ?Hora,                      ");
            query.Append(" ?Operador,                  ");
            query.Append(" ?Cliente,                   ");
            query.Append(" ?PlanoPagamento,            ");
            query.Append(" ?Valor,                     ");
            query.Append(" ?Desconto,                  ");
            query.Append(" ?OperadorDesconto,          ");
            query.Append(" ?QtdItens                   ");
            query.Append(" );                          ");
            query.Append(" SELECT LAST_INSERT_ID();    ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?NumeroDAVPreVenda", preVenda.NumeroDAVPreVenda);
            mySqlCommand.Parameters.AddWithValue("?NomeComputador", preVenda.NomeComputador);
            mySqlCommand.Parameters.AddWithValue("?Data", preVenda.Data);
            mySqlCommand.Parameters.AddWithValue("?Hora", preVenda.Hora);
            mySqlCommand.Parameters.AddWithValue("?Operador", preVenda.Usuario.UsuarioId);
            mySqlCommand.Parameters.AddWithValue("?Cliente", preVenda.Cliente.ClienteId);
            mySqlCommand.Parameters.AddWithValue("?PlanoPagamento", preVenda.PlanoPagamento.PlanoPagamentoId);
            mySqlCommand.Parameters.AddWithValue("?Valor", preVenda.Valor);
            mySqlCommand.Parameters.AddWithValue("?Desconto", preVenda.Desconto);
            mySqlCommand.Parameters.AddWithValue("?OperadorDesconto", preVenda.Usuario.UsuarioId);
            mySqlCommand.Parameters.AddWithValue("?QtdItens", preVenda.QuantidadeItens);
            preVenda.PreVendaId = Convert.ToInt32(mySqlCommand.ExecuteScalar());
        }
        
        public ulong GetNumeroDAVPreVenda()
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT sct_numero_dav_pv    ");
            query.Append(" FROM srv_contadores LIMIT 1 ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return Convert.ToUInt32(row["sct_numero_dav_pv"]);
            }

            return 0;
        }

        public void AddContadorDAV()
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO srv_contadores(sct_numero_dav_pv) VALUES(2); ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.ExecuteScalar();
        }

        public void UpdateContadorDAV(ulong numeroPreVenda)
        {
            var query = new StringBuilder();
            if (numeroPreVenda + 1 > 9999999999)
            {   
                query.Append(" UPDATE srv_contadores SET sct_numero_dav_pv=1; ");
            }
            else
            {
                query.Append(" UPDATE srv_contadores SET sct_numero_dav_pv=sct_numero_dav_pv+1; ");
                
            }
            var mySqlCommand = new MySqlCommand(
                    query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.ExecuteScalar();
        }

        public void TravaTabelaContador()
        {
            var query = new StringBuilder();
            query.Append(" LOCK TABLE srv_contadores WRITE; ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.ExecuteScalar();
        }

        public void DestravaTabelaContador()
        {
            var query = new StringBuilder();
            query.Append(" UNLOCK TABLES; ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.ExecuteScalar();
        }
    }
}
