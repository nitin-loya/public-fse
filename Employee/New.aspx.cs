using System;

namespace Cognizant_FSD.Employee
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            RefEmpService.EmployeeServiceClient svc = new RefEmpService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            
            svc.AddEmployee(new RefEmpService.Employee
            {
                EmpId = int.Parse(EmpNoTextBox.Text.Trim()),
                EmpFirstName = FirstNameTextBox.Text.Trim(),
                EmpLastName = LastNameTextBox.Text.Trim(),
                Dept = DeptTextBox.Text.Trim()
            });
            Response.Redirect("EmpList.aspx");
        }

    }
}