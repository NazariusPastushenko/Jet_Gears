using System.Data.SqlClient;

namespace Jet_Gears.DataBases
{
    public class DataBase
    {
        public SqlConnection sqlConnection =
            new SqlConnection("Server=192.168.56.1,1433;Database=Parts;User Id=jet_User;Password=naznaz123");


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