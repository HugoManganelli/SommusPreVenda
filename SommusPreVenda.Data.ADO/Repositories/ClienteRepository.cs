using MySql.Data.MySqlClient;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public Cliente Get(int clienteId)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT pes_codigo, pes_nome, pes_end_logradouro FROM srv_pessoas ");
            query.Append(" WHERE                     ");
            query.Append(" pes_cliente = 1 AND       ");
            query.Append(" pes_codigo = ?codigo      ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?codigo", clienteId);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var cliente = new Cliente()
                {
                    ClienteId = Convert.ToInt32(row["pes_codigo"]),
                    Nome = row["pes_nome"].ToString(),
                    Endereco = row["pes_end_logradouro"].ToString()
                };
                return cliente;
            }
            return new Cliente();            
        }

        public List<Cliente> Get(string pesquisa)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT pes_codigo, pes_nome, pes_end_logradouro FROM srv_pessoas   ");
            query.Append(" WHERE                       ");
            query.Append(" pes_cliente = 1 AND         ");
            query.Append(" pes_nome like ?pesquisa ");
            var mySqlCommand = new MySqlCommand(query.ToString(), 
                DataContext.MySqlConnection, 
                DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?pesquisa", "%"+pesquisa+"%");
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var clientes = new List<Cliente>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    var cliente = new Cliente()
                    {
                        ClienteId = Convert.ToInt32(row["pes_codigo"]),
                        Nome = row["pes_nome"].ToString(),
                        Endereco = row["pes_end_logradouro"].ToString()
                    };
                    clientes.Add(cliente);                    
                }
                return clientes;
            }
            return new List<Cliente>();
        }
    }
}
