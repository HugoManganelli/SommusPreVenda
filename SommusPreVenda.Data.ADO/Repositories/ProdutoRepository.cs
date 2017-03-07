using SommusPreVenda.Domain.Interfaces.Repositories;
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
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto Get(int produtoId)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM srv_produtos ");
            query.Append(" WHERE                      ");
            query.Append(" prd_ativo = 1 AND          ");
            query.Append(" prd_codigo = ?codigo       ");
            query.Append(" LEFT JOIN                  ");
            query.Append(" srv_produtos_estoque ON    ");
            query.Append(" est_produto = prd_codigo   ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(),DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?codigo", produtoId);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var produto = new Produto()
                {
                    ProdutoId = Convert.ToInt32(row["prd_codigo"]),
                    Descricao = row["prd_descricao"].ToString(),
                    Preco = Convert.ToDecimal(row["prd_preco_venda"]),
                    Estoque = Convert.ToDouble(row["est_estoque"])
                };
                return produto;
            }

            return new Produto();
        }

        public List<Produto> Get()
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM srv_produtos ");
            query.Append(" WHERE                      ");
            query.Append(" prd_ativo = 1 AND          ");            
            query.Append(" LEFT JOIN                  ");
            query.Append(" srv_produtos_estoque ON    ");
            query.Append(" est_produto = prd_codigo   ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);            
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var produtos = new List<Produto>();
                for (int i = 0; i < dataTable.Rows.Count; i++)               
                {
                    var row = dataTable.Rows[0];
                    var produto = new Produto()
                    {
                        ProdutoId = Convert.ToInt32(row["prd_codigo"]),
                        Descricao = row["prd_descricao"].ToString(),
                        Preco = Convert.ToDecimal(row["prd_preco_venda"]),
                        Estoque = Convert.ToDouble(row["est_estoque"])
                    };
                    produtos.Add(produto);
                }
                return produtos;
            }

            return new List<Produto>();
        }
    }
}
