using System.Data.SqlClient;

namespace regressed_security.Data;

public class Repository
{
    public async Task<int> GetData(string param)
    {
        SqlConnection con = new SqlConnection("localdb");
        SqlCommand sqlCommand = new SqlCommand($"SELECT TOP 1 ID FROM dbo.Table WHERE Id = ${param}");
        var result = await sqlCommand.ExecuteScalarAsync();
        return (int)result;
    }
}