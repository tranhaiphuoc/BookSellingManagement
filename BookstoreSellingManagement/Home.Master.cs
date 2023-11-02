using BookstoreSellingManagement.BAL.Services;
using System;

namespace BookstoreSellingManagement
{
    public partial class Home1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Lbtn_logOut_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            AuthService.LogOut(Page);
            Response.Redirect("/");
        }


        // ------------- Private Processing Methods ------------- //
        private void LoadCategory()
        {
            Rpt_bookCategory.DataSource = CategoryService.GetAll();
            Rpt_bookCategory.DataBind();
        }
    }
}