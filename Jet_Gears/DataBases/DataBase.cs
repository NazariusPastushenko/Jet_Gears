using System.Data.SqlClient;

namespace Jet_Gears.DataBases
{
    public class DataBase
    {
        public SqlConnection sqlConnection =
            new SqlConnection("Server=tcp:jetsgearsserver.database.windows.net,1433;Initial Catalog=Jet_Gears_DB;Persist Security Info=False;User ID=Nazarelo;Password=Naznaz123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


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