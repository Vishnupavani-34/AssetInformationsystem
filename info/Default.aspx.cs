using System;
namespace info
{ 
public partial class Default : System.Web.UI.Page
{
    protected void btnSystemConfig_Click(object sender, EventArgs e)
    {
        Response.Redirect("SystemConfig.aspx");
    }

    protected void btnEmployeeDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeDetailsTabulation.aspx");
    }
}
}
