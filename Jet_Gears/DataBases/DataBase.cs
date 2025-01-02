using System.Data.SqlClient;

namespace Jet_Gears.DataBases
{
    public class DataBase
    {
        public SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=DESKTOP-B61PS2D\SQLEXPRESS; Initial Catalog=Parts;Integrated Security=True");


        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        
        
        public  SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}