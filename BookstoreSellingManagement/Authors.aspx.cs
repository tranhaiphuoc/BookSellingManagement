using BookstoreSellingManagement.BAL.Services;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Authors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAuthors();
            }
        }


        // ------------- Commands and Events ------------- //
        protected void Btn_AddAuthor_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManageAuthor.aspx");
        }

        protected void Btn_EditAuthor_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"ManageAuthor.aspx?id={(string)e.CommandArgument}");
        }

        protected void Btn_ConfirmDeleteAuthor_Command(object sender, CommandEventArgs e)
        {
            Guid authorId = Guid.Parse(DeleteId.Value);

            AuthorService.Delete(authorId);
            LoadAuthors();
        }


        // ------------- Displayed Methods ------------- //
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
        private void LoadAuthors()
        {
            Rpt_AuthorsList.DataSource = AuthorService.GetAll();
            Rpt_AuthorsList.DataBind();
        }
    }
}