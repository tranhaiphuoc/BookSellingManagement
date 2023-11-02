using BookstoreSellingManagement.BAL.Services;
using System;
using System.Globalization;

namespace BookstoreSellingManagement
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                if (id != null)
                {
                    Guid orderId;

                    if (Guid.TryParse(id, out orderId))
                    {
                        Txt_total.InnerText += OrderService.GetOrderDetailsTotal(orderId).ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
                        Rpt_orderDetails.DataSource = OrderService.GetDetails(null, orderId);
                        Rpt_orderDetails.DataBind();

                        return;
                    }
                }

                Response.Redirect("NotFound.aspx");
            }
        }
    }
}