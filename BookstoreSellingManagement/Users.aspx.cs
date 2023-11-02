using BookstoreSellingManagement.BAL.Services;
using System;
using System.Web.UI.WebControls;
using BookstoreSellingManagement.Utilities;
using BookstoreSellingManagement.Enums;

namespace BookstoreSellingManagement
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
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

        protected void Btn_Add_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManageUser.aspx");
        }

        protected void Btn_Edit_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"ManageUser.aspx?id={(string)e.CommandArgument}");
        }

        protected void Btn_ConfirmDelete_Command(object sender, CommandEventArgs e)
        {
            Guid userId = Guid.Parse(DeleteId.Value);
            UserService.Delete(userId);
            LoadUsers();
        }


        private void LoadUsers()
        {
            Rpt_BooksList.DataSource = UserService.GetAll();
            Rpt_BooksList.DataBind();
        }
    }
}