using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.SqlClient;

// Define the connection string
string connectionString = "Softplus_OL";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();

    // Create and configure a command for the stored procedure
    using (SqlCommand cmd = new SqlCommand("InsertDataIntoTables", connection))
    {
        cmd.CommandType = CommandType.StoredProcedure;

        // Create and populate the MasterDetailData table parameter
        DataTable masterDetailData = new DataTable();
        masterDetailData.Columns.Add("MasterInfoID", typeof(int));
        masterDetailData.Columns.Add("MasterInfoName", typeof(string));

        // Add rows to the MasterDetailData table
        // ...

        SqlParameter masterDetailParam = cmd.Parameters.AddWithValue("@MasterDetailData", masterDetailData);
        masterDetailParam.SqlDbType = SqlDbType.Structured;
        masterDetailParam.TypeName = "dbo.MasterDetailInfoType";

        // Create and populate the DetailData table parameter
        DataTable detailData = new DataTable();
        detailData.Columns.Add("DetailInfoID", typeof(int));
        detailData.Columns.Add("MasterInfoID", typeof(int));
        detailData.Columns.Add("ItemSizeID", typeof(int));
        detailData.Columns.Add("Quantity", typeof(int));

        // Add rows to the DetailData table
        // ...

        SqlParameter detailParam = cmd.Parameters.AddWithValue("@DetailData", detailData);
        detailParam.SqlDbType = SqlDbType.Structured;
        detailParam.TypeName = "dbo.DetailInfoType";

        // Execute the stored procedure
        cmd.ExecuteNonQuery();
    }
    
}