using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryId = Request.QueryString["id"];

            if (queryId == null)
            {
                Response.Redirect("NotFound.aspx");
            }
            
            Guid id;

            if (Guid.TryParse(queryId, out id))
            {
                PopulateDataToPage(id);
            }
        }


        protected void Btn_addToCart_Command(object sender, CommandEventArgs e)
        {
            CartService.AddToCart(Page, Guid.Parse(e.CommandArgument.ToString()));
        }


        // ------------- Private Processing Methods ------------- //
        private void PopulateDataToPage(Guid id)
        {
            TblBook book = BookService.GetById(id);

            if (book == null)
            {
                Response.Redirect("NotFound.aspx");
            }

            Btn_addToCart.CommandArgument = book.Id.ToString();
            TblAuthorCollection bookAuthor = TblBook.GetTblAuthorCollection(id);
            TblCategoryCollection bookCategory = TblBook.GetTblCategoryCollection(id);

            book_img.Src = "img/book/" + book.Image;
            book_title.InnerText = book.Title;
            book_isbn.InnerText = book.Isbn;
            book_author.InnerText = string.Join(", ", TblBook.GetTblAuthorCollection(id).Select(a => a.Name).ToList());
            book_publisher.InnerText = (PublisherService.GetById(book.PublisherId)).Name;
            book_category.InnerText = string.Join(", ", TblBook.GetTblCategoryCollection(id).Select(c => c.Name).ToList());
            book_description.InnerText = book.Description;
        }
    }
}