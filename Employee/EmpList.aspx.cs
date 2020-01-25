using System;

namespace Cognizant_FSD.Employee
{
    public partial class EmpList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefEmpService.EmployeeServiceClient svc = new RefEmpService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");            
            EmpGrid.DataSource = svc.RetrieveEmployees();
            EmpGrid.DataBind();            
        }
    }
}