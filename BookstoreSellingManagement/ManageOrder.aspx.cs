using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using BookstoreSellingManagement.Utilities;
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class ManageOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatus();

                if (Request.QueryString["id"] != null)
                {
                    Guid id;
                    bool isValidId = Guid.TryParse(Request.QueryString["id"], out id);

                    if (isValidId)
                    {
                        PopulateDataToPage(id);
                    }
                    else
                    {
                        Response.Redirect("NotFound.aspx");
                    }
                }
                else
                {
                    Response.Redirect("NotFound.aspx");
                }
            }
        }


        // ------------- Commands and Events ------------- //
        protected void Btn_Submit_Command(object sender, CommandEventArgs e)
        {
            HttpCookie requestedCookie = Request.Cookies[AuthService.CookieName];

            if (requestedCookie != null)
            {
                if (Page.IsValid)
                {
                    TblUser user = UserService.GetById(Guid.Parse(requestedCookie[AuthService.Key_Id]));

                    TblOrder dbOrder = OrderService.GetById(Guid.Parse(Hf_orderId.Value));
                    dbOrder.DueDate = DateTime.Parse(Txt_dueDate.Value);
                    dbOrder.Status = Ddl_status.Value;
                    dbOrder.UpdatedBy = user.LastName;
                    dbOrder.UpdatedAt = DateTime.Now;

                    OrderService.Update(dbOrder);

                    Page.ShowToastr("Order has been succesfully updated!", "Delete", ToastrType.info.ToString());
                }
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Orders.aspx");
        }


        // ------------- Validators ------------- //
        protected void Cv_dueDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_dueDate.ErrorMessage = "Order's due date is required.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_orderStatus_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Ddl_status.SelectedIndex == -1)
            {
                Cv_orderStatus.ErrorMessage = "Order's status is required.";
                args.IsValid = false;
                return;
            }
        }


        // ------------- Private Methods For Processing ------------- //
        private void LoadStatus()
        {
            foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
            {
                Ddl_status.Items.Add(new ListItem(status.ToString(), status.ToString()));
            }
        }

        private void PopulateDataToPage(Guid orderId)
        {
            TblOrder order = OrderService.GetById(orderId);

            Hf_orderId.Value = order.Id.ToString();
            Txt_dueDate.Value = order.DueDate.ToString("yyyy-MM-dd");
            Txt_dueDate.Attributes.Add("min", DateTime.Now.ToString("yyyy-MM-dd"));
            Ddl_status.Items.FindByValue(order.Status).Selected = true;
        }
    }
}