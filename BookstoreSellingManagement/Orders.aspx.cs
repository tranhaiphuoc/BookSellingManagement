using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using BookstoreSellingManagement.Utilities;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }


        protected void Btn_EditOrder_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"ManageOrder.aspx?id={e.CommandArgument}");
        }

        protected void Btn_details_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"OrderDetails.aspx?id={e.CommandArgument}");
        }

        protected void Btn_ConfirmDeleteOrder_Command(object sender, CommandEventArgs e)
        {
            Guid orderId = Guid.Parse(DeleteId.Value);
            OrderService.Delete(orderId);
            LoadOrders();
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


        private void LoadOrders()
        {
            Rpt_BooksList.DataSource = OrderService.GetAll();
            Rpt_BooksList.DataBind();
        }
    }
}