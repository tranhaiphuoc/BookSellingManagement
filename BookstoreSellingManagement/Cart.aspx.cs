using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    LoadCart();
                }
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_deleteItem_Command(object sender, CommandEventArgs e)
        {
            Guid itemId;

            if (Guid.TryParse((string)e.CommandArgument, out itemId) == false) return;

            List<TblBook> books = (List<TblBook>)Session["Cart"];
            books.Remove(books.FirstOrDefault(x => x.Id == itemId));

            LoadCart();
        }

        protected void Btn_adjustQuantity_Command(object sender, CommandEventArgs e)
        {
            Guid itemId;

            if (Guid.TryParse(e.CommandArgument.ToString(), out itemId) == false) return;

            List<TblBook> books = (List<TblBook>)Session["Cart"];
            TblBook book = books.FirstOrDefault(x => x.Id == itemId);

            if (book == null) return;

            int quantityAvailable = (BookService.GetById(book.Id)).Quantity;

            switch (e.CommandName)
            {
                case "Add":
                    if (book.Quantity < quantityAvailable)
                    {
                        book.Quantity++;
                    }
                    break;

                case "Subtract":
                    if (book.Quantity > 1)
                    {
                        book.Quantity--;
                    }
                    break;
            }

            LoadCart();
        }

        protected void Btn_payment_Command(object sender, CommandEventArgs e)
        {
            HttpCookie requestedCookie = AuthService.GetUserCookie(Page);

            if (requestedCookie != null)
            {
                Response.Redirect("LogIn.aspx?redirect=Cart");
            }

            TblUser user = UserService.GetById(Guid.Parse(requestedCookie[AuthService.Key_Id]));

            if (user == null)
            {
                Page.ShowToastr("User validation error!", "Error", ToastrType.error.ToString());
                return;
            }

            Guid orderId = Guid.NewGuid();
            decimal subTotal = 0, discount = 0;
            TblOrderDetailCollection orderDetails = new TblOrderDetailCollection();

            foreach (var item in (List<TblBook>)Session["Cart"])
            {
                subTotal += item.Quantity * item.PriceOutput;

                orderDetails.Add(new TblOrderDetail()
                {
                    UnitPrice = item.PriceOutput,
                    Discount = 0,
                    Quantity = item.Quantity,
                    Total = item.PriceOutput * item.Quantity,
                    OrderId = orderId,
                    BookId = item.Id
                });
            }

            TblOrder order = new TblOrder()
            {
                Id = orderId,
                DueDate = DateTime.Now.AddDays(10),
                Status = OrderStatus.Delivering.ToString(),
                Subtotal = subTotal,
                TotalDiscount = discount,
                Total = subTotal + discount,
                CreatedBy = user.LastName,
                CreatedAt = DateTime.Now,
                UpdatedBy = user.LastName,
                UpdatedAt = DateTime.Now,
                UserId = user.Id
            };

            OrderService.Insert(order, orderDetails);
            foreach (var item in orderDetails)
            {
                BookService.UpdateQuantity(item);
            }

            Session["Cart"] = null;
            Page.ShowToastr("Order has been successfully created!", "Payment", ToastrType.success.ToString());
        }


        // ------------- Displayed Methods ------------- //
        protected int GetAvailableQuantity(Guid bookId)
        {
            return (BookService.GetById(bookId)).Quantity;
        }

        protected decimal GetAllItemsTotal()
        {
            List<TblBook> books = (List<TblBook>)Session["Cart"];
            decimal total = 0;

            foreach (var item in books)
            {
                total += item.Quantity * item.PriceOutput;
            }

            return total;
        }


        // ------------- Private Processing Methods ------------- //
        private void LoadCart()
        {
            Rpt_cartItems.DataSource = (List<TblBook>)Session["Cart"];
            Rpt_cartItems.DataBind();
        }
    }
}