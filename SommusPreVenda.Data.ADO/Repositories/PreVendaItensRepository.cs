using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SommusPreVenda.Domain.Entities;
using MySql.Data.MySqlClient;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class PreVendaItensRepository : IPreVendaItemRepository
    {
        public void Add(PreVendaItem preVendaItem)
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO srv_prevendas_itens( ");
            query.Append(" pvi_prevenda,                    ");
            query.Append(" pvi_data,                        ");
            query.Append(" pvi_hora,                        ");
            query.Append(" pvi_item,                        ");
            query.Append(" pvi_produto,                     ");
            query.Append(" pvi_quantidade,                  ");
            query.Append(" pvi_preco_cadastro,              ");
            query.Append(" pvi_preco_tabela1,               ");
            query.Append(" pvi_preco_tabela2,               ");
            query.Append(" pvi_preco_venda,                 ");
            query.Append(" pvi_desconto,                    ");
            query.Append(" pvi_operador,                    ");
            query.Append(" pvi_quem_concedeu_desconto)      ");
            query.Append(" VALUES(                          ");
            query.Append(" ?PreVendaId,                     ");
            query.Append(" ?Data,                           ");
            query.Append(" ?Hora,                           ");
            query.Append(" ?Registro,                       ");
            query.Append(" ?Produto,                        ");
            query.Append(" ?Quantidade,                     ");
            query.Append(" ?PrecoCadastro,                  ");
            query.Append(" ?PrecoTabela1,                   ");
            query.Append(" ?PrecoTabela2,                   ");
            query.Append(" ?PrecoVenda,                     ");
            query.Append(" ?Desconto,                       ");
            query.Append(" ?Operador,                       ");            
            query.Append(" ?ConcedeuDesconto);              ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?PreVendaId",preVendaItem.PreVendaId);
            mySqlCommand.Parameters.AddWithValue("?Data",preVendaItem.Data);
            mySqlCommand.Parameters.AddWithValue("?Hora",preVendaItem.Hora);
            mySqlCommand.Parameters.AddWithValue("?Registro",preVendaItem.Registro);
            mySqlCommand.Parameters.AddWithValue("?Produto",preVendaItem.Produto.ProdutoId);
            mySqlCommand.Parameters.AddWithValue("?Quantidade",preVendaItem.Quantidade);
            mySqlCommand.Parameters.AddWithValue("?PrecoCadastro", preVendaItem.PrecoTotalBruto);
            mySqlCommand.Parameters.AddWithValue("?PrecoTabela1",preVendaItem.PrecoTotalBruto);
            mySqlCommand.Parameters.AddWithValue("?PrecoTabela2", preVendaItem.PrecoTotalBruto);
            mySqlCommand.Parameters.AddWithValue("?PrecoVenda", preVendaItem.PrecoUnitario);
            mySqlCommand.Parameters.AddWithValue("?Desconto",preVendaItem.Desconto);
            mySqlCommand.Parameters.AddWithValue("?Operador",preVendaItem.Usuario.UsuarioId);
            mySqlCommand.Parameters.AddWithValue("?ConcedeuDesconto", preVendaItem.ConcedeuDesconto);
            mySqlCommand.ExecuteNonQuery();

        }
    }
}
