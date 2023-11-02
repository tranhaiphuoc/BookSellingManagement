using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class AllCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }

            string id = Request.QueryString["id"];

            if (id == null)
            {
                LoadBooks();
                return;
            }

            Guid categoryId;

            if (Guid.TryParse(id, out categoryId))
            {
                LoadBooks(categoryId);
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_ViewDetail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"Details.aspx?id={e.CommandArgument}");
        }

        protected void Btn_AddToCart_Command(object sender, CommandEventArgs e)
        {
            if (Session["Cart"] == null)
            {
                TblBook book = BookService.GetById(Guid.Parse((string)e.CommandArgument));
                book.Quantity = 1;

                List<TblBook> list = new List<TblBook> { book };
                Session["Cart"] = list;
            }
            else
            {
                List<TblBook> list = (List<TblBook>)Session["Cart"];

                Guid guid = Guid.Parse((string)e.CommandArgument);

                TblBook book = list.FirstOrDefault(x => x.Id == guid);

                if (book == null)
                {
                    book = BookService.GetById(guid);
                    book.Quantity = 1;

                    list.Add(book);
                }
                else
                {
                    TblBook dbBook = BookService.GetById(guid);

                    if (book.Quantity < dbBook.Quantity)
                    {
                        book.Quantity++;
                    }
                }
            }
        }


        // ------------- Private Processing Methods ------------- //
        private void LoadBooks()
        {
            Rpt_bookOfCategory.DataSource = BookService.GetAllForSale();
            Rpt_bookOfCategory.DataBind();
        }

        private void LoadBooks(Guid categoryId)
        {
            TblBookCollection coll = BookService.GetByCategory(0, categoryId);

            if (coll != null)
            {
                Rpt_bookOfCategory.DataSource = BookService.GetByCategory(0, categoryId);
                Rpt_bookOfCategory.DataBind();
                return;
            }

            Response.Redirect("NotFound.aspx");
        }

        private void LoadCategories()
        {
            Rpt_allCategory.DataSource = CategoryService.GetAll();
            Rpt_allCategory.DataBind();
        }
    }
}