﻿using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SommusPreVenda.Domain.Entities;
using System.Data;
using MySql.Data.MySqlClient;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public Cliente Get(int clienteId)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append("SELECT * FROM Srv_Pessoas        ");
            query.Append("WHERE                            ");
            query.Append("pes_cliente = 1 AND              ");
            query.Append("pes_codigo = ?codigo             ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?codigo", clienteId);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var cliente = new Cliente()
                {
                    ClienteId = Convert.ToInt32(row["clienteId"]),
                    Nome = row["pes_nome"].ToString(),
                    Endereco = row["pes_end_logradouro"].ToString()
                };
                return cliente;
            }
            return new Cliente();            
        }

        public List<Cliente> GetAll()
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append("SELECT * FROM Srv_Pessoas");
            query.Append("WHERE                    ");
            query.Append("pes_cliente = 1          ");
            var mySqlCommand = new MySqlCommand(query.ToString(), 
                DataContext.MySqlConnection, 
                DataContext.MySqlTransaction);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var clientes = new List<Cliente>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var row = dataTable.Rows[i];
                    var cliente = new Cliente()
                    {
                        ClienteId = Convert.ToInt32(row["clienteId"]),
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