using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using Fsd_Mvc_Assign.WcfService;
namespace Cognizant_FSD
{
    public partial class FSDServiceClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHTTP_Click(object sender, EventArgs e)
        {
            var greetingSvcAddress = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/CTS_FSD_Service/Hello/");
            var greetingSvcChannel = ChannelFactory<IHello>.CreateChannel(new WSHttpBinding(), greetingSvcAddress);
            lblHello.Text = greetingSvcChannel.SayHello(txtName.Text.Trim());
            lblbProgram.Text = greetingSvcChannel.TodayProgram(txtName.Text.Trim());
        }

        protected void btnTCP_Click(object sender, EventArgs e)
        {
            var greetingSvcAddress = new EndpointAddress("net.tcp://localhost:49538/WcfService/Hello.svc");
            var greetingSvcChannel = ChannelFactory<IHello>.CreateChannel(new NetTcpBinding(), greetingSvcAddress);
            lblHello.Text = greetingSvcChannel.SayHello(txtName.Text.Trim());
            lblbProgram.Text = greetingSvcChannel.TodayProgram(txtName.Text.Trim());

        }
    }
}