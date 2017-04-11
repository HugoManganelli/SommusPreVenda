using MySql.Data.MySqlClient;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Data;
using System.Text;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario Get(string login, string senha)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT ope_codigo, ope_nome, ope_senha_exp FROM srv_operadores ");
            query.Append(" WHERE ope_nome = ?login AND  ");
            query.Append(" ope_senha_exp = ?senha AND   ");
            query.Append(" ope_ativo = 1                ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?login", login);
            mySqlCommand.Parameters.AddWithValue("?senha", senha);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var usuario = new Usuario()
                {
                    UsuarioId = Convert.ToInt32(row["ope_codigo"]),
                    Login = row["ope_nome"].ToString(),
                    Senha = row["ope_senha_exp"].ToString()
                };
                return usuario;
            }
            return new Usuario();
        }
    }
}
