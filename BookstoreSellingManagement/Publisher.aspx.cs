using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Utilities;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Publisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPublisher();
            }
        }


        // ------------- Commands, Events and Page Methods ------------- //
        protected void Btn_Add_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManagePublisher.aspx");
        }

        protected void Btn_Edit_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"ManagePublisher.aspx?id={(string)e.CommandArgument}");
        }

        protected void Btn_ConfirmDelete_Command(object sender, CommandEventArgs e)
        {
            Guid publisherId = Guid.Parse(DeleteId.Value);
            PublisherService.Delete(publisherId);
            LoadPublisher();
        }

        protected string CutString(string str)
        {
            int value = 30;
            if (str.Length > value)
            {
                str = str.Substring(0, value) + "...";
            }
            return str;
        }


        // ------------- Private Methods For Processing ------------- //
        private void LoadPublisher()
        {
            Rpt_List.DataSource = PublisherService.GetAll();
            Rpt_List.DataBind();
        }
    }
}