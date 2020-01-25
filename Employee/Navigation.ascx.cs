using System;

namespace Cognizant_FSD.Employee
{
    public partial class Navigation : System.Web.UI.UserControl
    {
        public Pages CurrentPage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowLabels(false);
            ShowLinks(true);

            switch (CurrentPage)
            {
                case Pages.New:
                    NewMenu.Visible = false;
                    NewLabel.Visible = true;
                    break;
                case Pages.Edit:
                    EditMenu.Visible = false;
                    EditLabel.Visible = true;
                    break;
                case Pages.Delete:
                    DeleteMenu.Visible = false;
                    DeleteLabel.Visible = true;
                    break;
                default:
                    IndexMenu.Visible = false;
                    IndexLabel.Visible = true;
                    break;
            }
        }
        private void ShowLabels(bool flag)
        {
            IndexLabel.Visible = flag;
            NewLabel.Visible = flag;
            EditLabel.Visible = flag;
            DeleteLabel.Visible = flag;
        }

        private void ShowLinks(bool flag)
        {
            IndexMenu.Visible = flag;
            NewMenu.Visible = flag;
            EditMenu.Visible = flag;
            DeleteMenu.Visible = flag;
        }
    }
    public enum Pages
    {
        EmpList,
        New,
        Edit,
        Delete
    }

}