using Fsd_Mvc_Assign.SelfHostService;
using System;

namespace Fsd_Mvc_Assign.WCFService
{
    public partial class WCFServiceClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHTTP_Click(object sender, EventArgs e)
        {
            HelloClient objcl = new HelloClient("BasicHttpBinding_IHello");
            string str = txtName.Text.Trim();            
            lblHello.Text = objcl.SayHello(str);
            lblbProgram.Text = objcl.TodayProgram(txtName.Text.Trim());
        }

        protected void btnTCP_Click(object sender, EventArgs e)
        {
            HelloClient objcl = new HelloClient("NetTcpBinding_IHello");
            string str = txtName.Text.Trim();
            lblHello.Text = objcl.SayHello(str);
            lblbProgram.Text = objcl.TodayProgram(txtName.Text.Trim());
        }
    }
}