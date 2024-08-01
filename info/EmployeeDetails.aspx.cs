using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace info
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate DeviceIDDropDownList with device IDs
                PopulateDeviceIDs();
            }
        }

        private void PopulateDeviceIDs()
        {
            try
            {
                // Retrieve device IDs from database
                string connectionString = ConfigurationManager.ConnectionStrings["AssetInformation"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DeviceID, DeviceName FROM SystemConfigurations";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DeviceIDDropDownList.DataSource = reader;
                        DeviceIDDropDownList.DataTextField = "DeviceName";
                        DeviceIDDropDownList.DataValueField = "DeviceID";
                        DeviceIDDropDownList.DataBind();
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Response.Write("An error occurred while populating device IDs: " + ex.Message);
            }
        }

        protected void SaveDetailsButton_Click(object sender, EventArgs e)
        {
            string deviceID = DeviceIDDropDownList.SelectedValue;
            string ipAddress = IPAddressTextBox.Text;
            string employeeName = EmployeeNameTextBox.Text;

            try
            {
                // Check if the selected DeviceID exists in SystemConfigurations table
                if (DeviceIDExists(deviceID))
                {
                    // Save employee details to database
                    string connectionString = ConfigurationManager.ConnectionStrings["AssetInformation"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO EmployeeDetails (DeviceID, IPAddress, EmployeeName) " +
                                       "VALUES (@DeviceID, @IPAddress, @EmployeeName)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DeviceID", deviceID);
                            command.Parameters.AddWithValue("@IPAddress", ipAddress);
                            command.Parameters.AddWithValue("@EmployeeName", employeeName);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    // Redirect to EmployeeDetailsTabulation.aspx
                    Response.Redirect("EmployeeDetailsTabulation.aspx");
                }
                else
                {
                    // Handle case where DeviceID does not exist
                    Response.Write("Selected DeviceID does not exist. Please select a valid DeviceID.");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Response.Write("An error occurred while saving: " + ex.Message);
            }
        }

        private bool DeviceIDExists(string deviceID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssetInformation"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM SystemConfigurations WHERE DeviceID = @DeviceID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DeviceID", deviceID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
