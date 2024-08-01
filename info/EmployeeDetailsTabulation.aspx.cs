using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace info
{
    public partial class EmployeeDetailsTabulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeDetailsWithSystemConfigurations();
            }
        }

        private void LoadEmployeeDetailsWithSystemConfigurations()
        {
            try
            {
                // Load employee details with associated system configurations from database
                string connectionString = ConfigurationManager.ConnectionStrings["AssetInformation"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT e.DeviceID, e.IPAddress, e.EmployeeName, " +
                                   "s.DeviceName, s.Processor, s.InstalledRAM, s.SystemType, s.SystemVersion " +
                                   "FROM EmployeeDetails e " +
                                   "INNER JOIN SystemConfigurations s ON e.DeviceID = s.DeviceID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        EmployeeDetailsGridView.DataSource = dt;
                        EmployeeDetailsGridView.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Response.Write("An error occurred while loading data: " + ex.Message);
            }
        }
    }
}
