using MySql.Data.MySqlClient;
using SommusPreVenda.Domain.Interfaces.Repositories;
using System.Configuration;

namespace SommusPreVenda.Data.ADO.Repositories
{
    public class DataContext : IDataContext
    {
        public static MySqlConnection MySqlConnection { get; set; }
        public static MySqlTransaction MySqlTransaction { get; set; }

        public void BeginTransaction()
        {
            MySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnectionStringSrv"].ConnectionString);
            MySqlConnection.Open();
            MySqlTransaction = MySqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            MySqlTransaction.Commit();
        }

        public void Rollback()
        {
            MySqlTransaction.Rollback();
        }

        public void Finally()
        {
            if (MySqlConnection != null)
            {
                MySqlTransaction.Dispose();
                MySqlConnection.Dispose();
                MySqlConnection.Close();
            }
        }
    }
}
