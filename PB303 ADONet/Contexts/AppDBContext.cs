using System.Data;
using System.Data.SqlClient;

namespace PB303_ADONet.Contexts;

public static class AppDBContext
{
    private static string _connectionString = "Server=DESKTOP-U2HDDUL;Database=PB303AdoNet;Trusted_connection=true";
    private static SqlConnection sqlConnection = new(_connectionString);
    public static int ExecuteCommand(string cmd)
    {
        int result = 0;
        try
        {
            sqlConnection.Open();
            SqlCommand command = new(cmd, sqlConnection);
            result = command.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sqlConnection.Close();
        }

        return result;
    }

    public static DataTable ExecuteQuery(string query)
    {
        DataTable table = new DataTable();

        try
        {
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            
            adapter.Fill(table);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sqlConnection.Close();
        }

        return table;
    }
}
