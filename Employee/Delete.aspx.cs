using System;

namespace Cognizant_FSD.Employee
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            RefEmpService.EmployeeServiceClient svc = new RefEmpService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            svc.DeleteEmployee(int.Parse(EmpSearchBox.Text.Trim()));
            Response.Redirect("EmpList.aspx");
        }

    }
}