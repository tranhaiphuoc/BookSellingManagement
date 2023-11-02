using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using System;
using System.Globalization;
using System.Web;

namespace BookstoreSellingManagement
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = AuthService.GetUserCookie(Page);

                if (cookie == null)
                {
                    Response.Redirect("LogIn.aspx");
                }

                Guid id;
                bool isValid = Guid.TryParse(cookie[AuthService.Key_Id], out id);

                if (isValid)
                {
                    LoadOrder(id);
                }
            }
        }


        protected void Btn_orderDetails_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect($"OrderHistory.aspx?id={e.CommandArgument}");
        }


        private void LoadOrder(Guid userId)
        {
            string id = Request.QueryString["id"];

            if (id != null)
            {
                Guid orderId;

                if (Guid.TryParse(id, out orderId))
                {
                    Txt_total.InnerText += OrderService.GetOrderDetailsTotal(orderId).ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));

                    Rpt_orderDetails.DataSource = OrderService.GetDetails(userId, orderId);
                    Rpt_orderDetails.DataBind();
                }
            }
            else
            {
                TblOrderCollection orders = OrderService.GetAllByUserId(userId);

                if (orders != null)
                {
                    Rpt_pastOrder.DataSource = orders;
                    Rpt_pastOrder.DataBind();
                }
            }
        }
    }
}