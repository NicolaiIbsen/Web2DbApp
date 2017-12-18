using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Web2DbAppNet2.DataAccess
{
    public class Executor
    {
        #region Fields
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Web2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion

        #region Constructor
        public Executor()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Methods

        public DataSet Execute(string sqlQuery)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            DataSet set = new DataSet(" ");
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(set);
            }
            return set;
        }
        public void Execute(string procedureName, int two)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        #endregion
    }
}
