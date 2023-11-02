using BookstoreSellingManagement.BAL.Services;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpt_book.DataSource = BookService.GetCollection();
                rpt_book.DataBind();
            }
        }


        protected void Btn_ViewDetail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"Details.aspx?id={e.CommandArgument}");
        }

        protected void Btn_AddToCart_Command(object sender, CommandEventArgs e)
        {
            CartService.AddToCart(Page, Guid.Parse((string)e.CommandArgument));
        }
    }
}