using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace info
{
    public partial class SystemConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList(Processor, "SELECT ProcessorName FROM Processors");
                PopulateDropDownList(InstalledRAM, "SELECT RAMSize FROM RAMOptions");
                PopulateDropDownList(SystemType, "SELECT SystemTypeName FROM SystemTypes");
                PopulateDropDownList(SystemVersion, "SELECT VersionName FROM Versions");
            }
        }

        private void PopulateDropDownList(DropDownList ddl, string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssetInformation"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddl.DataSource = reader;
                    ddl.DataTextField = reader.GetName(0); 
                    ddl.DataValueField = reader.GetName(0); 
                    ddl.DataBind();
                }
            }
            ddl.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssetInformation"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SystemConfigurations (DeviceName, Processor, InstalledRAM, SystemType, SystemVersion) VALUES (@DeviceName, @Processor, @InstalledRAM, @SystemType, @SystemVersion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DeviceName", DeviceName.Text);
                    cmd.Parameters.AddWithValue("@Processor", Processor.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstalledRAM", InstalledRAM.SelectedValue);
                    cmd.Parameters.AddWithValue("@SystemType", SystemType.SelectedValue);
                    cmd.Parameters.AddWithValue("@SystemVersion", SystemVersion.SelectedValue);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            
            Response.Redirect("EmployeeDetails.aspx");
        }
    }
}
