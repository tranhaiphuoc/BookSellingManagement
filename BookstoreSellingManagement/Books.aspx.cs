using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Utilities;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBooks();
            }
        }


        protected string CutString(string str)
        {
            int value = 30;
            if (str.Length > value)
            {
                str = str.Substring(0, value);
                str += "...";
            }
            return str;
        }

        protected void Btn_AddBook_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManageBook.aspx");
        }

        protected void Btn_EditBook_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"ManageBook.aspx?id={(string)e.CommandArgument}");
        }

        protected void Btn_ConfirmDeleteBook_Command(object sender, CommandEventArgs e)
        {
            Guid bookId = Guid.Parse(DeleteId.Value);
            BookService.Delete(bookId);

            LoadBooks();
        }


        private void LoadBooks()
        {
            Rpt_BooksList.DataSource = BookService.GetAll();
            Rpt_BooksList.DataBind();
        }
    }
}