using System;

namespace Cognizant_FSD.Employee
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            RefEmpService.EmployeeServiceClient svc = new RefEmpService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            int empId = 0;
            int.TryParse(EmpSearchBox.Text.Trim(), out empId);
            var employee = svc.RetrieveEmployeeById(empId);
            FirstNameTextBox.Text = employee.EmpFirstName;
            LastNameTextBox.Text = employee.EmpLastName;
            DeptTextBox.Text = employee.Dept;
        }

protected void SaveButton_Click(object sender, EventArgs e)
        {
            RefEmpService.EmployeeServiceClient svc = new RefEmpService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");

            var employee = new RefEmpService.Employee()
            {
                EmpId = int.Parse(EmpSearchBox.Text),
                EmpFirstName = FirstNameTextBox.Text.Trim(),
                EmpLastName = LastNameTextBox.Text.Trim(),
                Dept = DeptTextBox.Text.Trim()
            };
            svc.UpdateEmployee(employee);
            Response.Redirect("EmpList.aspx");
        }

    }
}